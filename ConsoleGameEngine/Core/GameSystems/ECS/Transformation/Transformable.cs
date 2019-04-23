using ConsoleGameEngine.Core.Graphics;

namespace ConsoleGameEngine.Core.GameSystems.ECS.Transformation {

	/// <summary>
	/// The abstract class that can be applied 
	/// to any class that needs to have transform data.
	/// </summary>
	public abstract class Transformable {

		public Transform Transform;

		public Point Position {
			get => Transform.Position;
			set => Transform.Position = value;
		}
	}
}
