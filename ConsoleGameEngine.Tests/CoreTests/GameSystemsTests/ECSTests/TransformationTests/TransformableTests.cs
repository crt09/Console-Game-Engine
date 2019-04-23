using ConsoleGameEngine.Core.GameSystems.ECS.Transformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleGameEngine.Tests.CoreTests.GameSystemsTests.ECSTests.TransformationTests {
	internal class TransformableTest : Transformable { }

	[TestClass]
	public class TransformableTests {
		[TestMethod]
		public void PositionEqualsTransform() {
			var transformable = new TransformableTest();
			Assert.AreEqual(transformable.Transform.Position, transformable.Position);
		}
	}
}
