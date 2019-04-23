using ConsoleGameEngine.Core.Exceptions;
using System;
using System.Collections.Generic;

namespace ConsoleGameEngine.Core.GameSystems.DefaultSystem {

	/// <summary>
	/// The advanced collection of the game components.
	/// </summary>
	public class GameComponentsCollection {

		private readonly List<GameComponent> components;

		private readonly GameCore game;

		/// <param name="game">Game to which components are attached</param>
		public GameComponentsCollection(GameCore game) {
			components = new List<GameComponent>();
			this.game = game;
		}

		/// <summary>
		/// Add component to the components list.
		/// </summary>
		/// <param name="component">Component to add</param>
		/// <exception cref="NullReferenceException">
		/// Thrown when the component is null
		/// </exception>
		/// <exception cref="MultipleBaseException">
		/// Thrown when the component is already attached to another game
		/// </exception>
		/// <exception cref="MultipleAdditionException">
		/// Thrown when trying to add the component to the components list multiple times
		/// </exception>
		public void Add(GameComponent component) {
			if (component == null)
				throw new NullReferenceException();
			if (component.Game != null && component.Game != this.game)
				throw new MultipleBaseException(component.ToString(), game.ToString());
			if (components.Contains(component))
				throw new MultipleAdditionException(component.ToString(), game.ToString());
			components.Add(component);
			component.Initialize();
		}

		/// <summary>
		/// Remove component from the components list if found.
		/// </summary>
		/// <param name="component">Component to remove</param>
		/// <exception cref="NullReferenceException">Thrown when the component is null</exception>
		public void Remove(GameComponent component) {
			if (component == null)
				throw new NullReferenceException(nameof(component));
			components.Remove(component);
		}

		/// <summary>
		/// Clear components list.
		/// </summary>
		public void Clear() {
			components.Clear();
		}

		/// <summary>
		/// Cast components collection to list.
		/// </summary>
		/// <returns>Components collection as List</returns>
		public List<GameComponent> ToList() {
			return components;
		}
	}
}
