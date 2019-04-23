using ConsoleGameEngine.Core.Time;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleGameEngine.Tests.CoreTests.TimeTests {
	[TestClass]
	public class ElapsedTimeTests {
		private ElapsedTime time;

		[TestMethod]
		public void MillisecondsToSecondsConvertion() {
			time.Milliseconds = 900;
			Assert.AreEqual(0.9, time.Seconds);
		}

		[TestMethod]
		public void SecondsToMillisecondsConvertion() {
			time.Seconds = 2.4;
			Assert.AreEqual(2400, time.Milliseconds);
		}
	}
}
