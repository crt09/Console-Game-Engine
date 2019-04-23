using ConsoleGameEngine.Core.GameSystems.ECS.Graphics;
using ConsoleGameEngine.Core.Graphics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleGameEngine.Tests.CoreTests.GameSystemsTests.ECSTests.GraphicsTests {
	[TestClass]
	public class SpriteTextTests {
		[TestMethod]
		public void Bounds() {
			var sprite = new SpriteText();
			sprite.Text = "$#d\n#";
			var bounds = new Rectangle(0, 0, 3, 2);
			Assert.AreEqual(bounds, sprite.Bounds);
			Assert.AreEqual(bounds, sprite.AbsoluteBounds);
		}
	}
}
