using ConsoleGameEngine.Core.Graphics;

namespace ConsoleGameEngine.Core.GameSystems.ECS.Graphics {

	/// <summary>
	/// The sprite drawable component which working with Texture and draws it.
	/// </summary>
	public class Sprite : DrawableComponent {

		/// <summary>
		/// Current sprite texture.
		/// </summary>
		public ConsoleTexture Texture { get; private set; }

		/// <summary>
		/// Sprite bounds relative to the base entity.
		/// </summary>
		public Rectangle Bounds {
			get => new Rectangle(this.Position.X, this.Position.Y, this.Texture.Width, this.Texture.Height);
		}

		/// <summary>
		/// Sprite bounds relative to the scene.
		/// </summary>
		public Rectangle AbsoluteBounds {
			get => new Rectangle(this.AbsolutePosition.X, this.AbsolutePosition.Y, this.Texture.Width, this.Texture.Height);
		}

		public Sprite(ConsoleTexture texture) {
			this.SetTexture(texture);
		}

		public Sprite(char symbol) {
			this.SetTexture(symbol);
		}

		public Sprite(char symbol, Rectangle rect) {
			this.SetTexture(symbol, rect);
		}

		/// <summary>
		/// Set Texture to the sprite.
		/// </summary>
		/// <param name="texture">Texture to set</param>
		public void SetTexture(ConsoleTexture texture) {
			this.Texture = texture;
		}

		/// <summary>
		/// Set the one symbol Texture to the sprite.
		/// </summary>
		/// <param name="symbol"></param>
		public void SetTexture(char symbol) {
			var matrix = new char[1, 1];
			matrix[0, 0] = symbol;
			this.Texture = new ConsoleTexture(1, 1);
			this.Texture.SetData(matrix);
		}

		/// <summary>
		/// Set the solid rectangle Texture to the sprite.
		/// </summary>
		/// <param name="symbol">Rectangle symbol to fill</param>
		/// <param name="rect">Rectangle to set</param>
		public void SetTexture(char symbol, Rectangle rect) {
			var matrix = new char[rect.Width, rect.Height];
			for (int y = 0; y < rect.Height; y++)
				for (int x = 0; x < rect.Width; x++) {
					matrix[x, y] = symbol;
				}

			this.Texture = new ConsoleTexture(rect.Width, rect.Height);
			this.Texture.SetData(matrix);
			Transform.Position = new Point(rect.X, rect.Y);
		}

		/// <inheritdoc />
		public override void Draw() {
			this.Scene.Game.Graphics.Draw(this.Texture, new Point(this.ScreenPosition.X, this.ScreenPosition.Y));
			base.Draw();
		}
	}
}
