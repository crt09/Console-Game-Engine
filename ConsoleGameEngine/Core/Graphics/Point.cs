namespace ConsoleGameEngine.Core.Graphics {

	/// <summary>
	/// The struct, which contains the information about two coordinates (X and Y).
	/// </summary>
	public struct Point {

		public int X { get; set; }

		public int Y { get; set; }

		public Point(int x, int y) {
			X = x;
			Y = y;
		}

		/// <summary>
		/// Returns Point(0, 0).
		/// </summary>
		public static Point Zero {
			get => new Point(0, 0);
		}

		/// <summary>
		/// Returns Point(1, 1).
		/// </summary>
		public static Point One {
			get => new Point(1, 1);
		}

		#region Operators

		public static Point operator +(Point a, Point b) {
			return new Point(a.X + b.X, a.Y + b.Y);
		}

		public static Point operator +(Point a, int b) {
			return new Point(a.X + b, a.Y + b);
		}

		public static Point operator -(Point a, Point b) {
			return new Point(a.X - b.X, a.Y - b.Y);
		}

		public static Point operator -(Point a, int b) {
			return new Point(a.X - b, a.Y - b);
		}

		public static Point operator *(Point a, Point b) {
			return new Point(a.X * b.X, a.Y * b.Y);
		}

		public static Point operator *(Point a, int b) {
			return new Point(a.X * b, a.Y * b);
		}

		public static Point operator /(Point a, Point b) {
			return new Point(a.X / b.X, a.Y / b.Y);
		}

		public static Point operator /(Point a, int b) {
			return new Point(a.X / b, a.Y / b);
		}

		public static Point operator %(Point a, Point b) {
			return new Point(a.X % b.X, a.Y % b.Y);
		}

		public static Point operator %(Point a, int b) {
			return new Point(a.X % b, a.Y % b);
		}

		public static bool operator ==(Point a, Point b) {
			return a.X == b.X && a.Y == b.Y;
		}

		public static bool operator !=(Point a, Point b) {
			return a.X != b.X && a.Y != b.Y;
		}

		#endregion

		public override bool Equals(object obj) {
			return obj != null && (Point)obj == this;
		}

		public override int GetHashCode() {
			return base.GetHashCode();
		}
	}
}
