using ConsoleGameEngine.Core.Graphics;
using System.Linq;

namespace ConsoleGameEngine.Core.GameSystems.ECS.Graphics {

	/// <summary>
	/// The sprite text drawable component which draws text.
	/// </summary>
	public class SpriteText : DrawableComponent {

		/// <summary>
		/// Text bounds relative to the base entity.
		/// </summary>
		public Rectangle Bounds {
			get => new Rectangle(Position.X, Position.Y, Text.Split('\n')[0].Length, Text.Count(c => c == '\n') + 1);
		}

		/// <summary>
		/// Text bounds relative to the scene.
		/// </summary>
		public Rectangle AbsoluteBounds {
			get => new Rectangle(AbsolutePosition.X, AbsolutePosition.Y, Bounds.Width, Bounds.Height);
		}

		/// <summary>
		/// Text to draw on the game.
		/// </summary>
		public string Text { get; set; }

		/// <inheritdoc />
		public override void Draw() {
			if (this.Text != null)
				Scene.Game.Graphics.DrawString(this.Text, ScreenPosition);
			base.Draw();
		}
	}
}
