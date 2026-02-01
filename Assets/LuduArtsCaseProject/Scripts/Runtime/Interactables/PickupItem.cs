using UnityEngine;
using LuduArts.InteractionSystem.Core; // IInteractable için gerekli
using LuduArts.InteractionSystem.Data;
using LuduArts.InteractionSystem.Player;
using LuduArts.InteractionSystem.UI;

namespace LuduArts.InteractionSystem.Interactables
{
    /// <summary>
    /// It allows the player to pick up an item and add it to their inventory.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class PickupItem : MonoBehaviour, IInteractable
    {
        #region Fields

        [SerializeField] private ItemData m_ItemData;
        private Renderer m_Renderer;

        #endregion

        #region IInteractable Implementation
        public string DisplayName => m_ItemData != null ? m_ItemData.ItemName : "Unknown Item";
        public string ActionPrompt => "Click to Pickup";
        public float HoldDuration => 0f;
        public bool Interact(GameObject interactor)
        {
            return Pickup();
        }

        #endregion

        #region Unity Methods

        private void Awake()
        {
            UpdateVisuals();
        }

        private void OnValidate()
        {
            UpdateVisuals();
        }

        public void Initialize(ItemData data)
        {
            m_ItemData = data;
            UpdateVisuals();
        }

        /// <summary>
        /// Updates the item's visual representation based on its data.
        /// </summary>
        private void UpdateVisuals()
        {
            if (m_Renderer == null) m_Renderer = GetComponentInChildren<Renderer>();

            if (m_ItemData != null && m_Renderer != null)
            {
                m_Renderer.material.color = m_ItemData.ItemColor;
            }
        }
        private void OnMouseDown()
        {
            Pickup();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Attempts to pick up the item and add it to the player's inventory.
        /// </summary>
        private bool Pickup()
        {
            if (InventoryManager.Instance != null && m_ItemData != null)
            {
                bool added = InventoryManager.Instance.AddItem(m_ItemData);
                if (added)
                {
                    Destroy(gameObject);
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}