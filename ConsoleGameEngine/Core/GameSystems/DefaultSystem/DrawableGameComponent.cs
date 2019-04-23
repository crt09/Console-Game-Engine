namespace ConsoleGameEngine.Core.GameSystems.DefaultSystem {

	/// <summary>
	/// The drawable component of the default game system. 
	/// Inherit from the game component, can be drawn.
	/// </summary>
	public abstract class DrawableGameComponent : GameComponent {

		/// <summary>
		/// The order in which the Draw method will be called.
		/// </summary>
		public int DrawOrder { get; set; }

		/// <inheritdoc />
		public DrawableGameComponent(GameCore game) : base(game) { }

		/// <summary>
		/// Draw method that calls on 
		/// the each time after calling of the Update method.
		/// </summary>
		public virtual void Draw() { }
	}
}
