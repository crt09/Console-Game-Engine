using ConsoleGameEngine.Core.GameSystems.ECS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ConsoleGameEngine.Tests.CoreTests.GameSystemsTests.ECSTests {
	[TestClass]
	public class ComponentTests {
		private Component component;

		[TestInitialize]
		public void Initialize() {
			component = new Component();
		}

		[TestMethod]
		public void PropertiesNull() {
			var list = new List<string>();
			list.Remove(" ");

			Assert.IsNull(component.Scene);
			Assert.IsNull(component.Entity);

			var entity = new Entity();
			entity.AddComponent(component);

			Assert.IsNull(component.Scene);
			Assert.IsNotNull(component.Entity);

			var scene = new Scene();
			scene.AddEntity(entity);

			Assert.IsNotNull(component.Scene);
			Assert.IsNotNull(component.Entity);

			entity.RemoveComponent(component);

			Assert.IsNull(component.Scene);
			Assert.IsNull(component.Entity);

			scene.RemoveEntity(entity);
			entity.AddComponent(component);

			Assert.IsNull(component.Scene);
			Assert.IsNotNull(component.Entity);
		}
	}
}
