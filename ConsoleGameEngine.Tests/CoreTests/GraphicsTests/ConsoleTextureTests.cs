using System;
using ConsoleGameEngine.Core.Graphics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleGameEngine.Tests.CoreTests.GraphicsTests {
	[TestClass]
	public class ConsoleTextureTests {

		ConsoleTexture texture;

		[TestInitialize]
		public void Initialize() {
			texture = new ConsoleTexture(0, 0);
		}

		[TestCleanup]
		public void CleanUp() {
			texture = null;
		}

		[TestMethod]
		public void DefaultMatrixSizeIsTextureSize() {
			texture = new ConsoleTexture(11, 39);

			var matrix = texture.GetData();
			Assert.AreEqual(11, matrix.GetLength(1));
			Assert.AreEqual(39, matrix.GetLength(0));
		}

		[TestMethod]
		public void MatrixEqualGetSet() {
			var matrix = new char[,] {
				{ '#', '*', '8' },
				{ '1', '\0', '-' }
			};
			texture.SetData(matrix);

			Assert.AreEqual(matrix, texture.GetData());

			var matrix2 = new string[] {
				"#-##",
				"\01]34"
			};
			texture.SetData(matrix2);

			Assert.AreEqual(']', texture.GetData()[1, 2]);

		}

		[TestMethod]
		public void NormalizeMatrix() {
			var matrix = new string[] {
				"12",
				"34",
				"56"
			};
			texture.SetData(matrix);

			Assert.AreNotEqual('3', texture.GetData()[0, 1]);
			Assert.AreNotEqual('2', texture.GetData()[1, 0]);

			texture.Normalize();

			Assert.AreEqual('3', texture.GetData()[0, 1]);
			Assert.AreEqual('2', texture.GetData()[1, 0]);
		}
	}
}
