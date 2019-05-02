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
	public class Game : IDisposable {

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
					throw new MultipleBaseException(value.ToString(), this.ToString());
				value.Game = this;
				if (graphics != null)
					graphics.Game = null;
				graphics = value;
			}
		}
		private Renderer graphics;

		#endregion

		#region Private fields

		private int previousUpdateDeltaMilliseconds;
		private int previousDeltaMilliseconds;
		private int deltaMilliseconds;
		private int deltaAccumulatorMilliseconds;

		private readonly Timer debugTimer;
		private int debugFramesCounter;

		#endregion

		#region Class actions

		/// <param name="width">Game matrix width in symbols</param>
		/// <param name="height">Game matrix height in symbols</param>
		/// <param name="name">Game title, which also sets to console window</param>
		public Game(int width, int height, string name) {
			this.Width = width;
			this.Height = height;
			this.Title = name;
			Console.CursorVisible = false;
			Console.OutputEncoding = Encoding.UTF8;

			Matrix = new char[width, height];
			Graphics = new Renderer();

			previousDeltaMilliseconds = GetCurrentTimeMilliseconds();
			if (Debugger.IsAttached) {
				debugTimer = new Timer(1000);
				debugTimer.Elapsed += this.DebugTimerElapsed;
				debugTimer.Start();
			}
		}

		public void Dispose() {
			this.Exit();
		}

		#endregion

		#region Main game actions

		/// <summary>
		/// Initialize game and start the main lifecycle 
		/// in which the game is updating, drawing and rendering.
		/// </summary>
		public void Run() {
			this.GameRunning = true;
			this.Initialize();

			while (GameRunning) {
				// calculate delta time
				deltaMilliseconds = GetCurrentTimeMilliseconds() - previousDeltaMilliseconds;
				previousDeltaMilliseconds = GetCurrentTimeMilliseconds();
				// accumulate total time
				deltaAccumulatorMilliseconds += deltaMilliseconds;

				// run game update at the same rate as fps
				while (deltaAccumulatorMilliseconds > (1000 / this.TargetFrameRate)) {
					deltaAccumulatorMilliseconds -= 1000 / this.TargetFrameRate;
					if (deltaAccumulatorMilliseconds < 0)
						deltaAccumulatorMilliseconds = 0;

					// calculate udpate delta time
					DeltaTime.Elapsed = new ElapsedTime(GetCurrentTimeMilliseconds() - previousUpdateDeltaMilliseconds);
					previousUpdateDeltaMilliseconds = GetCurrentTimeMilliseconds();

					Input.Update();
					this.Update();
					this.UpdateConsoleWindowSize();

					if (Debugger.IsAttached) {
						debugFramesCounter++;
					}
				}

				this.Draw();
				Graphics.RenderMatrix();
			}
		}

		/// <summary>
		/// Stop game lyfecycle and cleanup game resources.
		/// </summary>
		public void Exit() {
			GameRunning = false;
			Console.Clear();
			if (Debugger.IsAttached) {
				debugTimer.Stop();
			}
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

		private void UpdateConsoleWindowSize() {
			int targetWidth = (Graphics.DrawSpaces ? this.Width * 2 : this.Width) + 1;
			if (Console.WindowWidth != targetWidth) {
				Console.WindowWidth = targetWidth;
			}

			int targetHeight = this.Height + 1;
			if (Console.WindowHeight != targetHeight) {
				Console.WindowHeight = targetHeight;
			}
		}

		private int GetCurrentTimeMilliseconds() {
			return (int)DateTimeOffset.Now.ToUnixTimeMilliseconds();
		}

		private void DebugTimerElapsed(object sender, ElapsedEventArgs e) {
			Console.Title = $"{this.Title} - FPS: {debugFramesCounter}";
			debugFramesCounter = 0;
		}

		#endregion
	}
}
