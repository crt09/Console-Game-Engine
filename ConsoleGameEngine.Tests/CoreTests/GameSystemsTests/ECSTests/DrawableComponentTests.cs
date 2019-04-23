using ConsoleGameEngine.Core.GameSystems.ECS;
using ConsoleGameEngine.Core.Graphics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleGameEngine.Tests.CoreTests.GameSystemsTests.ECSTests {
	[TestClass]
	public class DrawableComponentTests {
		[TestMethod]
		public void DefaultPositions() {
			var component = new DrawableComponent();
			Assert.AreEqual(Point.Zero, component.AbsolutePosition);
			Assert.AreEqual(Point.Zero, component.ScreenPosition);
		}
	}
}
