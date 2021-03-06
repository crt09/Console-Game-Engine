﻿using ConsoleGameEngine.Core.GameSystems.ECS.Transformation;
using ConsoleGameEngine.Core.Graphics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleGameEngine.Tests.CoreTests.GameSystemsTests.ECSTests.TransformationTests {
	[TestClass]
	public class CameraTests {
		private Camera camera;

		[TestInitialize]
		public void Initialize() {
			camera = new Camera(null);
		}

		[TestMethod]
		public void GameNull() {
			Assert.IsNull(camera.Scene);
		}

		[TestMethod]
		public void Bounds() {
			Assert.AreEqual(Rectangle.Zero, camera.Bounds);
		}
	}
}
