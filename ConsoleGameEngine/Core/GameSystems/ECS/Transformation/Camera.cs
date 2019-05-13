using ConsoleGameEngine.Core.Graphics;

namespace ConsoleGameEngine.Core.GameSystems.ECS.Transformation {

	/// <summary>
	/// The transformable camera class which contains the camera transform info.
	/// </summary>
	public class Camera : Transformable {

		/// <summary>
		/// Camera bounds, relative to the camera transform and the game size.
		/// </summary>
		public Rectangle Bounds {
			get => this.Scene?.Game != null
				? new Rectangle(this.Position.X, this.Position.Y, this.Scene.Game.Width, this.Scene.Game.Height)
				: new Rectangle(this.Position.X, this.Position.Y, 0, 0);
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
