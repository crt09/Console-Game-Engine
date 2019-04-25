using System.Linq;

namespace ConsoleGameEngine.Core.Graphics {

	/// <summary>
	/// The texture class that it contains the information 
	/// about texture and the texture data (as <see cref="System.Char"/>[,]).
	/// </summary>
	public class ConsoleTexture {

		/// <summary>
		/// Texture matrix width in symbols.
		/// </summary>
		public int Width { get; set; }

		/// <summary>
		/// Texture matrix height in symbols.
		/// </summary>
		public int Height { get; set; }

		private char[,] matrix;

		public ConsoleTexture(int width, int height) {
			this.matrix = new char[height, width];
			this.UpdateSize();
		}

		public ConsoleTexture(char[,] data) {
			this.SetData(data);
			this.UpdateSize();
		}

		public ConsoleTexture(string[] data) {
			this.SetData(data);
			this.UpdateSize();
		}

		public ConsoleTexture(string data) {
			this.SetData(data);
			this.UpdateSize();
		}

		/// <summary>
		/// Set the texture data as matrix of symbols.
		/// </summary>
		/// <param name="data">Matrix of symbols to set</param>
		public void SetData(char[,] data) {
			this.matrix = data;
		}

		/// <summary>
		/// Set the texture data as array of strings that it
		/// will be converted to the matrix of symbols.
		/// </summary>
		/// <param name="data">Array of strings to set</param>
		public void SetData(string[] data) {
			matrix = new char[data.Length, data.Max(c => c.Length)];
			for (int row = 0; row < data.Length; row++) {
				if (row >= matrix.GetLength(0))
					break;
				var symbols = data[row].ToCharArray();
				for (int col = 0; col < symbols.Length; col++) {
					if (col >= matrix.GetLength(1))
						break;
					this.matrix[row, col] = symbols[col];
				}
			}
		}

		/// <summary>
		/// Set the texture data as single string that it
		/// will be splitted by '\n' symbol and converted to the matrix of symbols.
		/// </summary>
		/// <param name="data">String to set</param>
		public void SetData(string data) {
			this.SetData(data.Split('\n'));
		}

		/// <summary>
		/// Flip X and Y texture matrix coordinates.
		/// </summary>
		public void Normalize() {
			var buffer = new char[matrix.GetLength(1), matrix.GetLength(0)];
			for (int y = 0; y < buffer.GetLength(1); y++)
				for (int x = 0; x < buffer.GetLength(0); x++) {
					buffer[x, y] = matrix[y, x];
				}
			this.matrix = buffer;
		}

		/// <summary>
		/// Get texture matrix.
		/// </summary>
		/// <returns>Matrix of symbols</returns>
		public char[,] GetData() {
			return this.matrix;
		}

		private void UpdateSize() {
			this.Width = this.matrix.GetLength(1);
			this.Height = this.matrix.GetLength(0);
		}
	}
}
