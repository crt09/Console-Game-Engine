using ConsoleGameEngine.Core.GameSystems.ECS.Transformation;

namespace ConsoleGameEngine.Core.GameSystems.ECS {

	/// <summary>
	/// The component of the entity. Can be updated.
	/// </summary>
	public class Component : Transformable {

		/// <summary>
		/// The order in which the Update method will be called.
		/// </summary>
		public int UpdateOrder { get; set; }

		/// <summary>
		/// Scene to which the component entity is attached.
		/// </summary>
		public Scene Scene {
			get => Entity?.Scene;
		}

		/// <summary>
		/// Entity to which component is attached.
		/// </summary>
		public Entity Entity { get; internal set; }

		/// <summary>
		/// Initialization method that it calls when
		/// the component is added to the entity components.
		/// </summary>
		public virtual void Initialize() { }

		/// <summary>
		/// Update method that it calls on 
		/// the each cycle of the game lifecycle.
		/// </summary>
		public virtual void Update() { }
	}
}
