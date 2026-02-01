using UnityEngine;
using LuduArts.InteractionSystem.Core;

namespace LuduArts.InteractionSystem.Interactables
{
    /// <summary>
    /// It transmits the interaction of a child object (e.g., Door Handle) to the parent object (e.g., Door).
    /// </summary>
    public class InteractablePart : MonoBehaviour, IInteractable
    {
        #region Fields

        [SerializeField] private MonoBehaviour m_MainInteractableScript;
        
        private IInteractable m_MainInteractable;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (m_MainInteractableScript is IInteractable interactable)
            {
                m_MainInteractable = interactable;
            }
            else
            {
                Debug.LogError($"{name}: Atanan script IInteractable arayüzünü uygulamıyor!");
            }
        }

        #endregion

        #region IInteractable Implementation

        public string DisplayName
        {
            get
            {
                return m_MainInteractable != null ? m_MainInteractable.DisplayName : "Unknown Object";
            }
        }

        public string ActionPrompt
        {
            get
            {
                return m_MainInteractable != null ? m_MainInteractable.ActionPrompt : "";
            }
        }
        public float HoldDuration
        {
            get
            {
                return m_MainInteractable != null ? m_MainInteractable.HoldDuration : 0f;
            }
        }

        public bool Interact(GameObject interactor)
        {
            if (m_MainInteractable != null)
            {
                return m_MainInteractable.Interact(interactor);
            }
            return false;
        }
        #endregion
    }
}