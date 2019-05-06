using ConsoleGameEngine.Core.Graphics;

namespace ConsoleGameEngine.Core.GameSystems.ECS.Transformation {

	/// <summary>
	/// The transormable camera class which contains the camera transform info.
	/// </summary>
	public class Camera : Transformable {

		/// <summary>
		/// Camera bounds, relative to the camera transform and the game size.
		/// </summary>
		public Rectangle Bounds {
			get => Scene?.Game != null
				? new Rectangle(Position.X, Position.Y, Scene.Game.Width, Scene.Game.Height)
				: new Rectangle(Position.X, Position.Y, 0, 0);
		}

		/// <summary>
		/// Game to which camera is attached.
		/// </summary>
		public Scene Scene { get; }

		/// <param name="scene">Scene to attach the camera</param>
		public Camera(Scene scene) {
			this.Scene = scene;
		}
	}
}
