using ConsoleGameEngine.Core.Graphics;

namespace ConsoleGameEngine.Core.GameSystems.ECS {

	/// <summary>
	/// The drawable component of the entity.
	/// Inherit from the component, can be drawn.
	/// </summary>
	public class DrawableComponent : Component {

		/// <summary>
		/// The order in which the Draw method will be called.
		/// </summary>
		public int DrawOrder { get; set; }

		/// <summary>
		/// Visibility of the component. If false, component will not be drawn.
		/// </summary>
		public bool Visible { get; set; } = true;

		/// <summary>
		/// Component absolute position relative to the camera.
		/// </summary>
		public Point ScreenPosition {
			get => Scene != null
				? AbsolutePosition - Scene.Camera.Transform.Position
				: AbsolutePosition;
		}

		/// <summary>
		/// Component position, relative to the scene.
		/// </summary>
		public Point AbsolutePosition {
			get => Entity != null
				? Entity.Transform.Position + Transform.Position
				: Transform.Position;
		}

		/// <summary>
		/// Draw method that it calls on 
		/// the each time after calling of the Update method.
		/// </summary>
		public virtual void Draw() { }
	}
}
