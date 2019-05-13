using System.Collections.Generic;
using System.Windows.Input;

namespace ConsoleGameEngine.Core.GameInput {

	/// <summary>
	/// The class which contains an information about pressed keys.
	/// </summary>
	public class KeyboardState {

		private List<Key> keys;

		public KeyboardState() {
			keys = new List<Key>();
		}

		/// <summary>
		/// Update the list of keys by key state (Down, Up).
		/// </summary>
		/// <param name="key">Key to handle</param>
		public void UpdateWith(Key key) {
			if (Keyboard.IsKeyDown(key) && !keys.Contains(key)) {
				keys.Add(key);
			} else if (Keyboard.IsKeyUp(key) && keys.Contains(key)) {
				keys.Remove(key);
			}
		}

		/// <summary>
		/// Checks if key is down by the saved keyboard state.
		/// </summary>
		/// <param name="key">Key to check</param>
		/// <returns>True if key down, otherwise false</returns>
		public bool IsKeyDown(Key key) {
			return keys.Contains(key);
		}

		/// <summary>
		/// Checks if key is up by the saved keyboard state.
		/// </summary>
		/// <param name="key">Key to check</param>
		/// <returns>True if key up, otherwise false</returns>
		public bool IsKeyUp(Key key) {
			return !keys.Contains(key);
		}

		/// <summary>
		/// Create a copy of the keyboard state and return it.
		/// </summary>
		/// <returns>Copy of the keyboard state</returns>
		public KeyboardState Clone() {
			var bufferKeys = new List<Key>();
			foreach (Key key in keys) {
				bufferKeys.Add(key);
			}
			var bufferState = new KeyboardState {
				keys = bufferKeys
			};
			return bufferState;
		}
	}
}
