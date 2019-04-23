using ConsoleGameEngine.Core.Graphics;

namespace ConsoleGameEngine.Core.GameSystems.ECS.Graphics {

	/// <summary>
	/// The sprite drawable component which working with texture and draws it.
	/// </summary>
	public class Sprite : DrawableComponent {

		private ConsoleTexture texture;

		/// <summary>
		/// Sprite bounds relative to the base entity.
		/// </summary>
		public Rectangle Bounds {
			get => new Rectangle(Position.X, Position.Y, texture.Width, texture.Height);
		}

		/// <summary>
		/// Sprite bounds relative to the scene.
		/// </summary>
		public Rectangle AbsoluteBounds {
			get => new Rectangle(AbsolutePosition.X, AbsolutePosition.Y, texture.Width, texture.Height);
		}

		public Sprite(ConsoleTexture texture) : base() {
			this.SetTexture(texture);
		}

		public Sprite(char symbol) : base() {
			this.SetTexture(symbol);
		}

		public Sprite(char symbol, Rectangle rect) : base() {
			this.SetTexture(symbol, rect);
		}

		/// <summary>
		/// Set texture to the sprite.
		/// </summary>
		/// <param name="texture">Texture to set</param>
		public void SetTexture(ConsoleTexture texture) {
			this.texture = texture;
		}

		/// <summary>
		/// Set the one symbol texture to the sprite.
		/// </summary>
		/// <param name="symbol"></param>
		public void SetTexture(char symbol) {
			var matrix = new char[1, 1];
			matrix[0, 0] = symbol;
			texture = new ConsoleTexture(1, 1);
			texture.SetData(matrix);
		}

		/// <summary>
		/// Set the solid rectangle texture to the sprite.
		/// </summary>
		/// <param name="symbol">Rectangle symbol to fill</param>
		/// <param name="rect">Rectangle to set</param>
		public void SetTexture(char symbol, Rectangle rect) {
			var matrix = new char[rect.Width, rect.Height];
			for (int y = 0; y < rect.Height; y++)
				for (int x = 0; x < rect.Width; x++) {
					matrix[x, y] = symbol;
				}
			texture = new ConsoleTexture(rect.Width, rect.Height);
			texture.SetData(matrix);
			Transform.Position = new Point(rect.X, rect.Y);
		}

		/// <inheritdoc />
		public override void Draw() {
			Scene.Game.Graphics.Draw(texture, new Point(ScreenPosition.X, ScreenPosition.Y));
			base.Draw();
		}
	}
}
