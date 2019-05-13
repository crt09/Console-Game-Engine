namespace ConsoleGameEngine.Core.Time {

	/// <summary>
	/// The struct that it contains the elapsed time data and converts milliseconds to seconds.
	/// </summary>
	public struct ElapsedTime {

		public int Milliseconds { get; set; }

		public double Seconds {
			get => (double) this.Milliseconds / 1000;
			set => this.Milliseconds = (int)(value * 1000);
		}

		public ElapsedTime(int milliseconds) {
			this.Milliseconds = milliseconds;
		}
	}
}
