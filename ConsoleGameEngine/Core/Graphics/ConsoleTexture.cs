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
		public int Width {
			get => matrix.GetLength(0);
		}

		/// <summary>
		/// Texture matrix height in symbols.
		/// </summary>
		public int Height {
			get => matrix.GetLength(1);
		}

		private char[,] matrix;

		public ConsoleTexture(int width, int height) {
			matrix = new char[height, width];
		}

		public ConsoleTexture(char[,] data) {
			SetData(data);
		}

		public ConsoleTexture(string[] data) {
			SetData(data);
		}

		public ConsoleTexture(string data) {
			SetData(data);
		}

		/// <summary>
		/// Set the texture data as matrix of symbols.
		/// </summary>
		/// <param name="data">Matrix of symbols to set</param>
		public void SetData(char[,] data) {
			matrix = data;
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
				char[] symbols = data[row].ToCharArray();
				for (int col = 0; col < symbols.Length; col++) {
					if (col >= matrix.GetLength(1))
						break;
					matrix[row, col] = symbols[col];
				}
			}
		}

		/// <summary>
		/// Set the texture data as single string that it
		/// will be splitted by '\n' symbol and converted to the matrix of symbols.
		/// </summary>
		/// <param name="data">String to set</param>
		public void SetData(string data) {
			SetData(data.Split('\n'));
		}

		/// <summary>
		/// Flip X and Y texture matrix coordinates.
		/// </summary>
		public ConsoleTexture Normalize() {
			var buffer = new char[matrix.GetLength(1), matrix.GetLength(0)];
			for (int y = 0; y < buffer.GetLength(1); y++)
				for (int x = 0; x < buffer.GetLength(0); x++) {
					buffer[x, y] = matrix[y, x];
				}
			matrix = buffer;
			return this;
		}

		/// <summary>
		/// Get texture matrix.
		/// </summary>
		/// <returns>Matrix of symbols</returns>
		public char[,] GetData() {
			return matrix;
		}
	}
}
