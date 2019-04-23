using ConsoleGameEngine.Core.GameSystems.ECS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleGameEngine.Tests.CoreTests.GameSystemsTests.ECSTests {
	internal class EntityChild : Entity { }

	[TestClass]
	public class SceneTests {
		private Scene scene;

		[TestInitialize]
		public void Initialize() {
			scene = new Scene();
		}

		[TestMethod]
		public void ProperiesNull() {
			Assert.IsNull(scene.Game);
			Assert.IsNotNull(scene.Camera);
			Assert.IsNull(scene.Camera.Game);
		}

		[TestMethod]
		public void Entities() {
			Assert.IsNull(scene.GetEntity<Entity>());
			Assert.AreEqual(0, scene.GetEntities().Length);

			var entity = new Entity();
			var entityChild = new EntityChild();
			scene.AddEntity(entity);
			scene.AddEntity(entityChild);

			Assert.IsNotNull(scene.GetEntity<Entity>());
			Assert.IsNotNull(scene.GetEntity<EntityChild>());
			Assert.AreEqual(2, scene.GetEntities().Length);
			Assert.AreEqual(2, scene.GetEntities<Entity>().Length);
			Assert.AreEqual(1, scene.GetEntities<EntityChild>().Length);
		}

		[TestMethod]
		public void EntitiesExceptions() {
			var scene2 = new Scene();
			var entity = new Entity();
			scene2.AddEntity(entity);

			bool fail = true;
			try {
				scene.AddEntity(entity);
				fail = false;
			} catch { }
			Assert.IsTrue(fail);

			fail = true;

			try {
				scene2.AddEntity(entity);
				fail = false;
			} catch { }
			Assert.IsTrue(fail);
		}
	}
}
