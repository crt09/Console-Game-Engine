using System;

namespace ConsoleGameEngine.Core.Exceptions {

	/// <summary>
	/// The exception that is thrown when 
	/// there is an attempt to add certain object to multiple bases.
	/// </summary>
	public class MultipleBaseException : Exception {

		private const string exceptionText = "Cannot add an instance to multiple bases.";

		public MultipleBaseException()
			: base(exceptionText) { }

		public MultipleBaseException(string instanceType, string baseType)
			: base($"{exceptionText}\n\nInstance: {instanceType}\nBase: {baseType}") { }
	}
}
