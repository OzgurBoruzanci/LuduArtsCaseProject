using UnityEngine;

namespace LuduArts.InteractionSystem.Core
{
    /// <summary>
    /// The interface that all objects with which the player can interact must implement.
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        /// The display name of the interactable object.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// The action prompt message for interaction (e.g., "Press E to Open").
        /// </summary>
        string ActionPrompt { get; }

        /// <summary>
        /// The duration the interaction needs to be held.
        /// 0 means instant interaction.
        /// </summary>
        float HoldDuration { get; }

        /// <summary>
        /// Method called when the player interacts with this object.
        /// </summary>
        /// <param name="interactor">The GameObject that is interacting (usually the player).</param>
        /// <returns>True if the interaction was successful, false otherwise.</returns>
        bool Interact(GameObject interactor);
    }
}