using ConsoleGameEngine.Core.Exceptions;
using System;

namespace ConsoleGameEngine.Core.GameSystems.ECS {

	/// <summary>
	/// The game core for the ECS game system.
	/// The ECS game system using the scenes that can 
	/// contain the entities that can contain the components
	/// that can be updated and drawn (if the component is drawable).
	/// </summary>
	public class GameCore : Game {

		/// <summary>
		/// Main game scene.
		/// </summary>
		/// <exception cref="NullReferenceException">
		/// Thrown when value is null
		/// </exception>
		/// <exception cref="MultipleBaseException">
		/// Thrown when scene is already a part of another game
		/// </exception>
		public Scene Scene {
			get => scene;
			set {
				if (value == null)
					throw new NullReferenceException();
				if (value.Game != null && value.Game != this)
					throw new MultipleBaseException(value.ToString(), ToString());
				value.Game = this;
				value.Initialize();
				if (scene != null) {
					scene.Game = null;
				}
				scene = value;
			}
		}
		private Scene scene;

		/// <inheritdoc />
		public GameCore(int width, int height, string name) : base(width, height, name) {
			Scene = new Scene();
		}

		/// <inheritdoc />
		protected override void Update() {
			Scene.Update();
		}

		/// <inheritdoc />
		protected sealed override void Draw() {
			Graphics.Clear(Scene.ClearSymbol);
			Scene.Draw();
		}
	}
}
