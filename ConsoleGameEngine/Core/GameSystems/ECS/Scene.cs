using ConsoleGameEngine.Core.Exceptions;
using ConsoleGameEngine.Core.GameSystems.ECS.Transformation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGameEngine.Core.GameSystems.ECS {

	/// <summary>
	/// The game scene which can contains and handles entities.
	/// </summary>
	public class Scene {

		/// <summary>
		/// Game to which scene is attached.
		/// </summary>
		public GameCore Game { get; internal set; }

		/// <summary>
		/// Scene camera. Instantiated only in ctor and can't be reinitialized.
		/// </summary>
		public Camera Camera { get; }

		/// <summary>
		/// Symbol to clear the game screen
		/// </summary>
		public char ClearSymbol { get; set; }

		private readonly List<Entity> entities;

		/// <param name="clearSymbol">Symbol to clear game the screen</param>
		public Scene(char clearSymbol = ' ') {
			this.ClearSymbol = clearSymbol;
			entities = new List<Entity>();
			this.Camera = new Camera(this);
		}

		/// <summary>
		/// Initialization method that calls when
		/// the scene was attached to the game.
		/// </summary>
		public virtual void Initialize() { }

		/// <summary>
		/// Update method that calls on 
		/// the each cycle of the game lifecycle.
		/// Updates all entities on the scene.
		/// </summary>
		public virtual void Update() {
			var entitiesBuffer = this.entities
				.OrderBy(item => item.UpdateOrder)
				.ToList();
			for (int i = 0; i < entitiesBuffer.Count; i++) {
				entitiesBuffer[i].Update();
			}
		}

		internal void Draw() {
			var entitiesBuffer = this.entities
				.OrderBy(item => item.DrawOrder)
				.ToList();
			for (int i = 0; i < entitiesBuffer.Count; i++) {
				entitiesBuffer[i].Draw();
			}
		}

		/// <summary>
		/// Add entity to the entities list.
		/// </summary>
		/// <param name="entity">Entity to add</param>
		/// <exception cref="NullReferenceException">
		/// Thrown when the entity is null
		/// </exception>
		/// <exception cref="MultipleBaseException">
		/// Thrown when the entity is already a part of another scene
		/// </exception>
		/// <exception cref="MultipleAdditionException">
		/// Thrown when trying to add the entity to the entities list multiple times
		/// </exception>
		public void AddEntity(Entity entity) {
			if (entity == null)
				throw new ArgumentNullException();
			if (entity.Scene != null && entity.Scene != this)
				throw new MultipleBaseException(entity.ToString(), this.ToString());
			if (entities.Contains(entity))
				throw new MultipleAdditionException(entity.ToString(), this.ToString());
			entity.Scene = this;
			entity.Initialize();
			entities.Add(entity);
		}

		/// <summary>
		/// Remove entity from entities list if found.
		/// </summary>
		/// <param name="entity">Entity to remove</param>
		/// /// <exception cref="NullReferenceException">
		/// Thrown when the entity is null
		/// </exception>
		public void RemoveEntity(Entity entity) {
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));
			if (entities.Contains(entity)) {
				entity.Scene = null;
				entities.Remove(entity);
			}
		}

		/// <summary>
		/// Clear entities list.
		/// </summary>
		public void ClearEntities() {
			entities.Clear();
		}

		/// <summary>
		/// Get the first entity of the specified type from the entities list.
		/// </summary>
		/// <typeparam name="TEntity">Entity type to get</typeparam>
		/// <returns>Enity of the specified type if found, otherwise null</returns>
		public TEntity GetEntity<TEntity>() where TEntity : Entity {
			return entities.FirstOrDefault(item => item is TEntity) as TEntity;
		}

		/// <summary>
		/// Get all entities of the specified type from the entities list.
		/// </summary>
		/// <typeparam name="TEntity">Entity type to get</typeparam>
		/// <returns>Entities list of the specified type</returns>
		public TEntity[] GetEntities<TEntity>() where TEntity : Entity {
			return entities
				.Where(item => item is TEntity)
				.Cast<TEntity>()
				.ToArray();
		}

		/// <summary>
		/// Get all entities from the entities list.
		/// </summary>
		/// <returns>Entities list</returns>
		public Entity[] GetEntities() {
			return entities.ToArray();
		}
	}
}
