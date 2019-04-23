namespace ConsoleGameEngine.Core.Time {

	/// <summary>
	/// The static class, using for delta time management by the game.
	/// </summary>
	public static class DeltaTime {

		/// <summary>
		/// Elapsed delta time.
		/// </summary>
		public static ElapsedTime Elapsed { get; internal set; }
	}
}
