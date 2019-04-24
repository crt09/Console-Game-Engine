using ConsoleGameEngine.Core.GameInput;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;

namespace ConsoleGameEngine.Tests.CoreTests.HelpersTests {
	[TestClass]
	public class InputTests {
		[TestMethod]
		public void NotPressed() {
			Assert.IsFalse(Input.IsKeyPressed(Key.R));
			Assert.IsFalse(Input.IsKeyReleased(Key.P));
			Assert.IsFalse(Input.IsKeyDown(Key.Escape));
		}
	}
}
