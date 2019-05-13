using ConsoleGameEngine.Core.Exceptions;
using ConsoleGameEngine.Core.GameSystems.ECS.Transformation;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ConsoleGameEngine.Core.GameSystems.ECS {

	/// <summary>
	/// The entity of the scene which can contains and handles components.
	/// </summary>
	[SuppressMessage("ReSharper", "ForCanBeConvertedToForeach")]
	public class Entity : Transformable {

		/// <summary>
		/// Scene to which entity is attached.
		/// </summary>
		public Scene Scene { get; internal set; }

		/// <summary>
		/// The order in which the Update method will be called.
		/// </summary>
		public int UpdateOrder { get; set; }

		/// <summary>
		/// The order in which the Draw method will be called.
		/// </summary>
		public int DrawOrder { get; set; }

		private readonly List<Component> components;

		public Entity() {
			components = new List<Component>();
		}

		/// <summary>
		/// Initialization method that calls when
		/// the entity was added to the scene.
		/// </summary>
		public virtual void Initialize() { }

		/// <summary>
		/// Update method that calls on 
		/// the each cycle of the game lifecycle.
		/// Updates all components of the entity.
		/// </summary>
		public virtual void Update() {
			List<Component> componentsBuffer = components
				.OrderBy(item => item.UpdateOrder)
				.ToList();
			for (int i = 0; i < componentsBuffer.Count; i++) {
				componentsBuffer[i].Update();
			}
		}

		internal void Draw() {
			List<DrawableComponent> componentsBuffer = components
				.Where(item => item is DrawableComponent drawableItem && drawableItem.Visible)
				.Cast<DrawableComponent>()
				.OrderBy(item => item.DrawOrder)
				.ToList();
			for (int i = 0; i < componentsBuffer.Count; i++) {
				componentsBuffer[i].Draw();
			}
		}

		/// <summary>
		/// Add component to the components list.
		/// </summary>
		/// <param name="component">Component to add</param>
		/// <exception cref="NullReferenceException">
		/// Thrown when the component is null
		/// </exception>
		/// <exception cref="MultipleBaseException">
		/// Thrown when the component is already a part of another entity
		/// </exception>
		/// <exception cref="MultipleAdditionException">
		/// Thrown when trying to add the component to the components list multiple times
		/// </exception>
		public void AddComponent(Component component) {
			if (component == null)
				throw new ArgumentNullException();
			if (component.Entity != null && component.Entity != this)
				throw new MultipleBaseException(component.ToString(), this.ToString());
			if (components.Contains(component))
				throw new MultipleAdditionException(component.ToString(), this.ToString());
			component.Entity = this;
			component.Initialize();
			components.Add(component);
		}

		/// <summary>
		/// Remove component from the components list.
		/// </summary>
		/// <param name="component">Component to remove</param>
		/// <exception cref="NullReferenceException">
		/// Thrown when the component is null
		/// </exception>
		public void RemoveComponent(Component component) {
			if (component == null)
				throw new ArgumentNullException(nameof(component));
			if (components.Contains(component)) {
				component.Entity = null;
				components.Remove(component);
			}
		}

		/// <summary>
		/// Clear components list.
		/// </summary>
		public void ClearComponents() {
			components.Clear();
		}

		/// <summary>
		/// Get the first component of the specified type from the components list.
		/// </summary>
		/// <returns>Component of the specified type if found, otherwise null</returns>
		public TComponent GetComponent<TComponent>() where TComponent : Component {
			return components.FirstOrDefault(item => item is TComponent) as TComponent;
		}

		/// <summary>
		/// Get all components of the specified type from the components list.
		/// </summary>
		/// <returns>Components list of the specified type</returns>
		public TComponent[] GetComponents<TComponent>() where TComponent : Component {
			return components
				.Where(item => item is TComponent)
				.Cast<TComponent>()
				.ToArray();
		}

		/// <summary>
		/// Get all components from the components list.
		/// </summary>
		/// <returns>Components list</returns>
		public Component[] GetComponents() {
			return components.ToArray();
		}
	}
}
