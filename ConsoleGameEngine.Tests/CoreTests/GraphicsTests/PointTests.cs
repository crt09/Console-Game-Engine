using ConsoleGameEngine.Core.Graphics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleGameEngine.Tests.CoreTests.GraphicsTests {
	[TestClass]
	public class PointTests {
		[TestMethod]
		public void Operators() {
			int x = 10;
			int y = 10;
			var point = new Point(x, y);

			Assert.AreEqual(new Point(20, 20), point * 2);
			Assert.AreEqual(new Point(13, 13), point + 3);
			Assert.AreEqual(new Point(19, 3), point + new Point(9, -7));
			Assert.AreEqual(new Point(2, 5), point / new Point(5, 2));
		}
	}
}
