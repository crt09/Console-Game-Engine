using ConsoleGameEngine.Core.Graphics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleGameEngine.Tests.CoreTests.GraphicsTests {
	[TestClass]
	public class RectangleTests {
		private Rectangle rect;

		[TestInitialize]
		public void Initialize() {
			rect = new Rectangle(4, 4, 3, 7);
		}

		[TestMethod]
		public void Containment() {
			Assert.IsTrue(rect.Contains(new Point(6, 5)));
			Assert.IsTrue(rect.Contains(new Point(4, 4)));
			Assert.IsTrue(rect.Contains(new Point(6, 10)));

			Assert.IsFalse(rect.Contains(new Point(3, 6)));
			Assert.IsFalse(rect.Contains(new Point(7, 11)));
			Assert.IsFalse(rect.Contains(Point.Zero));
		}

		[TestMethod]
		public void Intersection() {
			var box = new Rectangle(1, 1, 5, 5);
			Assert.IsTrue(rect.Intersects(box));

			box = new Rectangle(6, 3, 2, 2);
			Assert.IsTrue(rect.Intersects(box));

			box = new Rectangle(2, 6, 3, 1);
			Assert.IsTrue(rect.Intersects(box));


			box = new Rectangle(0, 0, 1, 1);
			Assert.IsFalse(rect.Intersects(box));

			box = new Rectangle(7, 10, 2, 2);
			Assert.IsFalse(rect.Intersects(box));

			box = new Rectangle(3, 3, 1, 1);
			Assert.IsFalse(rect.Intersects(box));
		}

		[TestMethod]
		public void Static() {
			Assert.AreEqual(new Point(5, 7), rect.Center);
			Assert.AreEqual(new Point(1, 3), rect.HalfSize);
		}
	}
}
