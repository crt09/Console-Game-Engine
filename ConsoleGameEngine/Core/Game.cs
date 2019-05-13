using ConsoleGameEngine.Core.Exceptions;
using ConsoleGameEngine.Core.GameInput;
using ConsoleGameEngine.Core.Graphics;
using ConsoleGameEngine.Core.Time;
using System;
using System.Diagnostics;
using System.Text;
using System.Timers;

namespace ConsoleGameEngine.Core {

	/// <summary>
	/// The main game engine core.
	/// Contains initialization, updating and drawing logic.
	/// </summary>
	public class Game {

		#region Public properties

		/// <summary>
		/// Game matrix width in symbols.
		/// </summary>
		public int Width { get; set; }

		/// <summary>
		/// Game matrix height in symbols.
		/// </summary>
		public int Height { get; set; }

		/// <summary>
		/// Game title, which also sets to console window.
		/// </summary>
		/// <exception cref="NullReferenceException">Thrown when value is null</exception>
		public string Title {
			get => title;
			set {
				title = value ?? throw new NullReferenceException();
				Console.Title = value;
			}
		}
		private string title;

		/// <summary>
		/// Game lifecycle frame rate. Using only for Update calls.
		/// </summary>
		public int TargetFrameRate { get; set; } = 60;

		/// <summary>
		/// Game running state. Sets to true automatically, when the game starts.
		/// </summary>
		public bool GameRunning { get; private set; }

		/// <summary>
		/// Game matrix size in symbols. Unites game matrix width and height.
		/// </summary>
		public Rectangle Bounds {
			get => new Rectangle(0, 0, Width, Height);
		}

		#endregion

		#region Public fields

		internal char[,] Matrix;

		/// <summary>
		/// The main game renderer. Using for elements drawing on the game matrix.
		/// </summary>
		/// <exception cref="MultipleBaseException">Thrown when renderer is already a part of another game</exception>
		public Renderer Graphics {
			get => graphics;
			set {
				if (value.Game != null && value.Game != this)
					throw new MultipleBaseException(value.ToString(), ToString());
				value.Game = this;
				if (graphics != null)
					graphics.Game = null;
				graphics = value;
			}
		}
		private Renderer graphics;

		#endregion

		#region Private members

		private int previousUpdateTime;
		private int previousTime;
		private int deltaTime;
		private int deltaTimeAccumulator;

		private readonly Timer debugTimer;
		private int debugFramesCounter;

		private static bool IsDebug {
			get => Debugger.IsAttached;
		}

		#endregion

		#region Class actions

		/// <param name="width">Game matrix width in symbols</param>
		/// <param name="height">Game matrix height in symbols</param>
		/// <param name="name">Game title, which also sets to console window</param>
		public Game(int width, int height, string name) {
			Width = width;
			Height = height;
			Title = name;
			Console.CursorVisible = false;
			Console.OutputEncoding = Encoding.UTF8;

			Matrix = new char[width, height];
			Graphics = new Renderer();

			previousTime = GetCurrentTimeMilliseconds();
			if (IsDebug) {
				debugTimer = new Timer(1000);
				debugTimer.Elapsed += DebugTimerElapsed;
				DebugTimerTick();
				debugTimer.Start();
			}
		}

		#endregion

		#region Main game actions

		/// <summary>
		/// Initialize game and start the main lifecycle 
		/// in which the game is updating, drawing and rendering.
		/// </summary>
		public void Run() {
			GameRunning = true;
			Initialize();

			while (GameRunning) {
				// calculate delta time
				int currentTime = GetCurrentTimeMilliseconds();
				deltaTime = currentTime - previousTime;
				previousTime = currentTime;
				// accumulate total time
				deltaTimeAccumulator += deltaTime;

				// run game update at the same rate as fps
				int targetDelay = 1000 / TargetFrameRate;
				while (deltaTimeAccumulator > targetDelay) {
					deltaTimeAccumulator -= targetDelay;
					if (deltaTimeAccumulator < 0)
						deltaTimeAccumulator = 0;

					// calculate update delta time
					int currentUpdateTime = GetCurrentTimeMilliseconds();
					int updateDeltaTime = currentUpdateTime - previousUpdateTime;
					if (updateDeltaTime > 0) {
						DeltaTime.Elapsed = new ElapsedTime(updateDeltaTime);
					}
					previousUpdateTime = currentUpdateTime;

					Input.Update();
					Update();
					TrimConsoleWindow();

					if (IsDebug) {
						debugFramesCounter++;
					}
				}

				Draw();
				Graphics.RenderMatrix();
			}

			Console.Clear();
			if (IsDebug) {
				debugTimer.Stop();
				debugTimer.Dispose();
			}
			Console.CursorVisible = true;
			ProcessModule mainModule = Process.GetCurrentProcess().MainModule;
			if (mainModule != null)
				Console.Title = mainModule.FileName;

			GC.Collect(1, GCCollectionMode.Forced);
			GC.WaitForPendingFinalizers();
		}

		/// <summary>
		/// Stop game lifecycle.
		/// </summary>
		public void Exit() {
			GameRunning = false;
		}

		#endregion

		#region Game lifecycle methods

		/// <summary>
		/// Initialization method that calls once 
		/// after calling Run method, before the start of the game lifecycle.
		/// </summary>
		protected virtual void Initialize() { }

		/// <summary>
		/// Update method that calls on 
		/// the each cycle of the game lifecycle.
		/// </summary>
		protected virtual void Update() { }

		/// <summary>
		/// Draw method that calls on 
		/// the each time after calling of the Update method.
		/// </summary>
		protected virtual void Draw() { }

		#endregion

		#region Additional private methods

		private void TrimConsoleWindow() {
			int targetWidth = (Graphics.DrawSpaces ? Width * 2 : Width) + 1;
			if (Console.WindowWidth != targetWidth) {
				Console.WindowWidth = targetWidth;
			}

			int targetHeight = Height + 1;
			if (Console.WindowHeight != targetHeight) {
				Console.WindowHeight = targetHeight;
			}
		}

		private int GetCurrentTimeMilliseconds() {
			return (int)DateTimeOffset.Now.ToUnixTimeMilliseconds();
		}

		private void DebugTimerElapsed(object sender, ElapsedEventArgs e) {
			DebugTimerTick();
		}

		private void DebugTimerTick() {
			Console.Title = $"{Title} - FPS: {debugFramesCounter} - DeltaTime.Milliseconds: {DeltaTime.Elapsed.Milliseconds}";
			debugFramesCounter = 0;
		}

		#endregion
	}
}
