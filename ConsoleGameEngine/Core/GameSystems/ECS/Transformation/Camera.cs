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
			get => Game != null
				? new Rectangle(Position.X, Position.Y, Game.Width, Game.Height)
				: new Rectangle(Position.X, Position.Y, 0, 0);
		}

		/// <summary>
		/// Game to which camera is attached.
		/// </summary>
		public GameCore Game { get; internal set; }
	}
}
