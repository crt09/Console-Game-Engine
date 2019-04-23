using ConsoleGameEngine.Core.GameSystems.ECS.Graphics;
using ConsoleGameEngine.Core.Graphics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleGameEngine.Tests.CoreTests.GameSystemsTests.ECSTests.GraphicsTests {
	[TestClass]
	public class SpriteTests {
		[TestMethod]
		public void Bounds() {
			var bounds = new Rectangle(1, 4, 15, 3);
			var sprite = new Sprite(' ', bounds);
			Assert.AreEqual(bounds, sprite.Bounds);
			Assert.AreEqual(bounds, sprite.AbsoluteBounds);
		}
	}
}
