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
			get => new Rectangle(Position.X, Position.Y, Texture.Width, Texture.Height);
		}

		/// <summary>
		/// Sprite bounds relative to the scene.
		/// </summary>
		public Rectangle AbsoluteBounds {
			get => new Rectangle(AbsolutePosition.X, AbsolutePosition.Y, Texture.Width, Texture.Height);
		}

		public Sprite(ConsoleTexture texture) {
			SetTexture(texture);
		}

		public Sprite(char symbol) {
			SetTexture(symbol);
		}

		public Sprite(char symbol, Rectangle rect) {
			SetTexture(symbol, rect);
		}

		/// <summary>
		/// Set Texture to the sprite.
		/// </summary>
		/// <param name="texture">Texture to set</param>
		public void SetTexture(ConsoleTexture texture) {
			Texture = texture;
		}

		/// <summary>
		/// Set the one symbol Texture to the sprite.
		/// </summary>
		/// <param name="symbol"></param>
		public void SetTexture(char symbol) {
			var matrix = new char[1, 1];
			matrix[0, 0] = symbol;
			Texture = new ConsoleTexture(1, 1);
			Texture.SetData(matrix);
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

			Texture = new ConsoleTexture(rect.Width, rect.Height);
			Texture.SetData(matrix);
			Transform.Position = new Point(rect.X, rect.Y);
		}

		/// <inheritdoc />
		public override void Draw() {
			Scene.Game.Graphics.Draw(Texture, new Point(ScreenPosition.X, ScreenPosition.Y));
			base.Draw();
		}
	}
}
