namespace ConsoleGameEngine.Core.Graphics {

	/// <summary>
	/// The struct which contains the information
	/// about rectangle (coordinates and size).
	/// </summary>
	public struct Rectangle {

		public int X { get; set; }

		public int Y { get; set; }

		public int Width { get; set; }

		public int Height { get; set; }

		public Rectangle(int x, int y, int width, int height) {
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}

		public Rectangle(Point position, Point size) {
			X = position.X;
			Y = position.Y;
			Width = size.X;
			Height = size.Y;
		}

		/// <summary>
		/// Returns Rectangle(0, 0, 0, 0).
		/// </summary>
		public static Rectangle Zero {
			get => new Rectangle(0, 0, 0, 0);
		}

		/// <summary>
		/// Returns the coordinates of the center point of the rectangle.
		/// </summary>
		public Point Center {
			get => new Point(X + (Width / 2), Y + (Height / 2));
		}

		/// <summary>
		/// Returns the half size of each side of the rectangle.
		/// </summary>
		public Point HalfSize {
			get => new Point(Width / 2, Height / 2);
		}

		/// <summary>
		/// Сhecks whether the point is in the rectangle.
		/// </summary>
		/// <param name="point">Point to check</param>
		/// <returns>Point is in the rectangle</returns>
		public bool Contains(Point point) {
			return point.X >= X
				&& point.X < X + Width
				&& point.Y >= Y
				&& point.Y < Y + Height;
		}

		/// <summary>
		/// Сhecks whether the point is in the rectangle.
		/// </summary>
		/// <param name="x">The X coordinate of the point</param>
		/// <param name="y">The Y coordinate of the point</param>
		/// <returns>Point is in the rectangle</returns>
		public bool Contains(int x, int y) {
			return Contains(new Point(x, y));
		}

		/// <summary>
		/// Checks if the rectangle intersects with another rectangle.
		/// </summary>
		/// <param name="rect">Rectangle to check intersection</param>
		/// <returns>Rectangles intersects</returns>
		public bool Intersects(Rectangle rect) {
			return rect.X + rect.Width > X
				&& rect.X < X + Width
				&& rect.Y + rect.Height > Y
				&& rect.Y < Y + Height;
		}
	}
}
