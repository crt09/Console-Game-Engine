using System;

namespace ConsoleGameEngine.Core.Graphics {

	/// <summary>
	/// The graphics class that it drawing and rendering game matrix.
	/// </summary>
	public class Renderer {

		/// <summary>
		/// Game to render the matrix.
		/// </summary>
		public Game Game { get; internal set; }

		internal void RenderMatrix() {
			Console.SetCursorPosition(0, 0);
			string buffer = string.Empty;
			for (int y = 0; y < Game.Height; y++) {
				for (int x = 0; x < Game.Width; x++) {
					buffer += Game.Matrix[x, y];
					if (Game.DrawSpaces) {
						buffer += ' ';
					}
				}
				buffer += '\n';
			}
			Console.Write(buffer);
		}

		/// <summary>
		/// Clear the game matrix and fill in with a certain symbol.
		/// </summary>
		/// <param name="symbol">Symbol to fill the game matrix</param>
		public void Clear(char symbol) {
			for (int y = 0; y < Game.Height; y++) {
				for (int x = 0; x < Game.Width; x++) {
					Game.Matrix[x, y] = symbol;
				}
			}
		}

		/// <summary>
		/// Draw single point on the game matrix.
		/// </summary>
		/// <param name="symbol">Symbol of the point to draw</param>
		/// <param name="position">Position of the point</param>
		public void Draw(char symbol, Point position) {
			var gameRect = new Rectangle(0, 0, Game.Width, Game.Height);
			if (gameRect.Contains(position) && symbol != ' ') {
				Game.Matrix[position.X, position.Y] = symbol;
			}
		}

		/// <summary>
		/// Draw rectangle on the game matrix (position sets by the rectangle position).
		/// </summary>
		/// <param name="symbol">Symbol to fill the rectangle and draw it</param>
		/// <param name="rect">Rectangle to draw</param>
		public void Draw(char symbol, Rectangle rect) {
			for (int y = rect.Y; y < rect.Y + rect.Height; y++) {
				for (int x = rect.X; x < rect.X + rect.Width; x++) {
					this.Draw(symbol, new Point(x, y));
				}
			}
		}

		/// <summary>
		/// Draw texture on the game matrix.
		/// </summary>
		/// <param name="texture">Texture to draw</param>
		/// <param name="position">Position of the texture</param>
		public void Draw(ConsoleTexture texture, Point position) {
			for (int y = 0; y < texture.Height; y++) {
				for (int x = 0; x < texture.Width; x++) {
					var textureMatrix = texture.GetData();
					var textureMatrixBounds = new Rectangle(0, 0, textureMatrix.GetLength(0), textureMatrix.GetLength(1));
					if (textureMatrixBounds.Contains(x, y)) {
						this.Draw(textureMatrix[x, y], new Point(x + position.X, y + position.Y));
					}
				}
			}
		}

		/// <summary>
		/// Draw  text on the game matrix.
		/// </summary>
		/// <param name="text">Text to draw</param>
		/// <param name="position">Position of the text</param>
		public void DrawString(string text, Point position) {
			var lines = text.Split('\n');
			for (int y = 0; y < lines.Length; y++) {
				for (int x = 0; x < lines[y].Length; x++) {
					this.Draw(lines[y][x], new Point(x + position.X, y + position.Y));
				}
			}
		}
	}
}
