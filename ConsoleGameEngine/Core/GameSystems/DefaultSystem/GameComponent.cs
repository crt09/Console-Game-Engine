namespace ConsoleGameEngine.Core.GameSystems.DefaultSystem {

	/// <summary>
	/// The component of the default game system. Can be updated.
	/// </summary>
	public abstract class GameComponent {

		/// <summary>
		/// The order in which the Update method will be called.
		/// </summary>
		public int UpdateOrder { get; set; }

		/// <summary>
		/// Game to which component is attached.
		/// </summary>
		protected internal GameCore Game { get; private set; }

		/// <param name="game">Game to attach</param>
		public GameComponent(GameCore game) {
			this.Game = game;
		}

		/// <summary>
		/// Initialization method that calls when
		/// the component is added to the game components.
		/// </summary>
		public virtual void Initialize() { }

		/// <summary>
		/// Update method that calls on 
		/// the each cycle of the game lifecycle.
		/// </summary>
		public virtual void Update() { }
	}
}
