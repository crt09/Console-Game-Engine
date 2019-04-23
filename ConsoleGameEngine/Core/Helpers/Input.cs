using System.Collections.Generic;
using System.Windows.Input;

namespace ConsoleGameEngine.Core.Helpers {

	/// <summary>
	/// The static class, using for keyboard input management.
	/// This class using the <see cref="System.Windows.Input.Keyboard"/> 
	/// class from System.Windows.Input and requires for the WindowsBase reference.
	/// </summary>	
	public static class Input {

		private static readonly List<Key> pressedKeys;
		private static readonly List<Key> keysToRelease;

		static Input() {
			pressedKeys = new List<Key>();
			keysToRelease = new List<Key>();
		}

		/// <summary>
		/// Checks if key is currently down.
		/// </summary>
		/// <param name="key">Key to check</param>
		/// <returns>Is key down</returns>
		public static bool IsKeyDown(Key key) {
			return Keyboard.IsKeyDown(key);
		}

		/// <summary>
		/// Checks if key was pressed once.
		/// </summary>
		/// <param name="key">Key to check</param>
		/// <returns>Key was pressed</returns>
		public static bool IsKeyPressed(Key key) {
			if(!pressedKeys.Contains(key) && Keyboard.IsKeyDown(key)) {
				pressedKeys.Add(key);
				return true;
			} else if (pressedKeys.Contains(key) && Keyboard.IsKeyUp(key)) {
				pressedKeys.Remove(key);
			}
			return false;
		}

		/// <summary>
		/// Checks if key was released once.
		/// </summary>
		/// <param name="key">Key to check</param>
		/// <returns>Key was released</returns>
		public static bool IsKeyReleased(Key key) {
			if (keysToRelease.Contains(key) && Keyboard.IsKeyUp(key)) {
				keysToRelease.Remove(key);
				return true;
			} else if (!keysToRelease.Contains(key) && Keyboard.IsKeyDown(key)) {
				keysToRelease.Add(key);
			}
			return false;
		}
	}
}
