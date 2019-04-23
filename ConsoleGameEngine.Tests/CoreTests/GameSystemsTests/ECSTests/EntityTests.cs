using ConsoleGameEngine.Core.GameSystems.ECS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleGameEngine.Tests.CoreTests.GameSystemsTests.ECSTests {
	[TestClass]
	public class EntityTests {
		private Entity entity;

		[TestInitialize]
		public void Initialize() {
			entity = new Entity();
		}

		[TestMethod]
		public void PropertiesNull() {
			Assert.IsNull(entity.Scene);

			var scene = new Scene();
			scene.AddEntity(entity);

			Assert.IsNotNull(entity.Scene);
			Assert.IsNull(entity.Scene.Game);

			scene.RemoveEntity(entity);

			Assert.IsNull(entity.Scene);
		}

		[TestMethod]
		public void Components() {
			Assert.IsNull(entity.GetComponent<Component>());
			Assert.AreEqual(0, entity.GetComponents().Length);

			var component = new Component();
			var drawableComponent = new DrawableComponent();
			entity.AddComponent(component);
			entity.AddComponent(drawableComponent);

			Assert.IsNotNull(entity.GetComponent<Component>());
			Assert.IsNotNull(entity.GetComponent<DrawableComponent>());
			Assert.AreEqual(2, entity.GetComponents().Length);
			Assert.AreEqual(2, entity.GetComponents<Component>().Length);
			Assert.AreEqual(1, entity.GetComponents<DrawableComponent>().Length);
		}

		[TestMethod]
		public void ComponentsExceptions() {
			var entity2 = new Entity();
			var component = new Component();
			entity2.AddComponent(component);

			bool fail = true;
			try {
				entity.AddComponent(component);
				fail = false;
			} catch { }
			Assert.IsTrue(fail);

			fail = true;

			try {
				entity2.AddComponent(component);
				fail = false;
			} catch { }
			Assert.IsTrue(fail);
		}
	}
}
