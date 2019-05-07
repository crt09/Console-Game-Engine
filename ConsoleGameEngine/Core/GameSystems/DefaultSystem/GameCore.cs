using System.Linq;

namespace ConsoleGameEngine.Core.GameSystems.DefaultSystem {

	/// <summary>
	/// The game core for the default game system.
	/// The default game system using the game components which 
	/// can be updated and drawn (if the game component is drawable).
	/// </summary>
	public class GameCore : Game {

		/// <summary>
		/// Game components list.
		/// </summary>
		public GameComponentsCollection Components;

		/// <inheritdoc />
		public GameCore(int width, int height, string name) : base(width, height, name) {
			Components = new GameComponentsCollection(this);
		}

		/// <inheritdoc />
		/// <summary>
		/// Updates all game components.
		/// </summary>
		protected override void Update() {
			var componentsBuffer = this.Components
				.ToList()
				.OrderBy(item => item.UpdateOrder)
				.ToList();
			for (int i = 0; i < componentsBuffer.Count; i++) {
				componentsBuffer[i].Update();
			}
		}

		/// <inheritdoc />
		/// <summary>
		/// Draws all drawable game components.
		/// </summary>
		protected override void Draw() {
			var componentsBuffer = this.Components
				.ToList()
				.Where(item => item is DrawableGameComponent)
				.Cast<DrawableGameComponent>()
				.OrderBy(item => item.DrawOrder)
				.ToList();
			for (int i = 0; i < componentsBuffer.Count; i++) {
				componentsBuffer[i].Draw();
			}
		}
	}
}
