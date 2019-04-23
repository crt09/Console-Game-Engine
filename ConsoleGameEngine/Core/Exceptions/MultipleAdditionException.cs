using System;

namespace ConsoleGameEngine.Core.Exceptions {

	/// <summary>
	/// The exception that is thrown when
	/// there is an attempt to add certain object to one base multiple times.
	/// </summary>
	public class MultipleAdditionException : Exception {

		private static string exceptionText { get; set; } = "Cannot add an instance to base multiple times.";

		public MultipleAdditionException()
			: base(exceptionText) { }

		public MultipleAdditionException(string instanceType, string baseType)
			: base($"{exceptionText}\n\nInstance: {instanceType}\nBase: {baseType}") { }
	}
}
