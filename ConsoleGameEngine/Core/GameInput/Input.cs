using System.Windows.Input;

namespace ConsoleGameEngine.Core.GameInput {

	/// <summary>
	/// The static class, using for keyboard input management.
	/// This class using the <see cref="System.Windows.Input.Keyboard"/> 
	/// class from System.Windows.Input and requires for the WindowsBase reference.
	/// </summary>	
	public static class Input {

		private static readonly KeyboardState currentKeyboardState;
		private static KeyboardState previousKeyboardState;

		static Input() {
			currentKeyboardState = new KeyboardState();
			previousKeyboardState = new KeyboardState();
		}

		internal static void Update() {
			previousKeyboardState = currentKeyboardState.Clone();
		}

		/// <summary>
		/// Checks if key is currently down.
		/// </summary>
		/// <param name="key">Key to check</param>
		/// <returns>True if key is down, otherwise false</returns>
		public static bool IsKeyDown(Key key) {
			currentKeyboardState.UpdateWith(key);
			return Keyboard.IsKeyDown(key);
		}

		/// <summary>
		/// Checks if key was pressed once.
		/// </summary>
		/// <param name="key">Key to check</param>
		/// <returns>True if key was pressed, otherwise false</returns>
		public static bool IsKeyPressed(Key key) {
			currentKeyboardState.UpdateWith(key);
			return currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key);
		}

		/// <summary>
		/// Checks if key was released once.
		/// </summary>
		/// <param name="key">Key to check</param>
		/// <returns>True if key was released, otherwise false</returns>
		public static bool IsKeyReleased(Key key) {
			currentKeyboardState.UpdateWith(key);
			return currentKeyboardState.IsKeyUp(key) && previousKeyboardState.IsKeyDown(key);
		}
	}
}
