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
			get => new Rectangle(this.Position.X, this.Position.Y, this.Text.Split('\n')[0].Length, this.Text.Count(c => c == '\n') + 1);
		}

		/// <summary>
		/// Text bounds relative to the scene.
		/// </summary>
		public Rectangle AbsoluteBounds {
			get => new Rectangle(this.AbsolutePosition.X, this.AbsolutePosition.Y, this.Bounds.Width, this.Bounds.Height);
		}

		/// <summary>
		/// Text to draw on the game.
		/// </summary>
		public string Text { get; set; }

		/// <inheritdoc />
		public override void Draw() {
			if (this.Text != null)
				this.Scene.Game.Graphics.DrawString(this.Text, this.ScreenPosition);
			base.Draw();
		}
	}
}
