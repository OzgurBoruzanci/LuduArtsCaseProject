using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LuduArts.InteractionSystem.Data;
using LuduArts.InteractionSystem.Interactables;
using LuduArts.InteractionSystem.Player; // PickupItem için

namespace LuduArts.InteractionSystem.UI
{
    /// <summary>
    /// It manages the player's inventory, allowing item pickup, equipping, and UI updates.
    /// </summary>
    public class InventoryManager : MonoBehaviour
    {
        #region Fields
        public static InventoryManager Instance { get; private set; }
        
        [Header("Settings")]
        [SerializeField] private int m_SlotCount = 3;
        [SerializeField] private Transform m_HandPosition;

        [Header("UI References")]
        [SerializeField] private Image[] m_SlotImages;
        [SerializeField] private Color m_EmptySlotColor = new Color(1, 1, 1, 0.2f);
        [SerializeField] private Color m_FullSlotColor = Color.white;

        // Private state
        private ItemData[] m_InventorySlots;
        private GameObject m_CurrentHandObject;
        private ItemData m_CurrentHeldItemData;

        #endregion

        #region Properties

        public ItemData HeldItem => m_CurrentHeldItemData;
        public GameObject HandObject => m_CurrentHandObject;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else { Destroy(gameObject); return; }

            m_InventorySlots = new ItemData[m_SlotCount];
            UpdateUI();
        }

        private void Update()
        {
            HandleInput();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles input for equipping items from inventory slots.
        /// </summary>
        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) EquipItem(0);
            if (Input.GetKeyDown(KeyCode.Alpha2)) EquipItem(1);
            if (Input.GetKeyDown(KeyCode.Alpha3)) EquipItem(2);
        }

        /// <summary>
        /// Adds the specified item to the inventory if there is an empty slot.
        /// </summary>
        public bool AddItem(ItemData item)
        {
            for (int i = 0; i < m_InventorySlots.Length; i++)
            {
                if (m_InventorySlots[i] == null)
                {
                    m_InventorySlots[i] = item;
                    UpdateUI();
                    if (InteractionDetector.Instance != null)
                        InteractionDetector.Instance.ShowMessage($"{item.ItemName} Added");
                        
                    return true;
                }
            }
            if (InteractionDetector.Instance != null)
                InteractionDetector.Instance.ShowMessage("Inventory Full!");
                
            return false;
        }

        /// <summary>
        /// The item in the specified slot is TRADED for the item in hand.
        /// </summary>
        private void EquipItem(int slotIndex)
        {
            if (slotIndex >= m_InventorySlots.Length) return;
            if (m_InventorySlots[slotIndex] == null && m_CurrentHeldItemData == null) return;
            ItemData previousHeldItem = m_CurrentHeldItemData;
            ItemData newItemToEquip = m_InventorySlots[slotIndex];
            if (m_CurrentHandObject != null)
            {
                Destroy(m_CurrentHandObject);
                m_CurrentHandObject = null;
            }
            m_InventorySlots[slotIndex] = previousHeldItem;
            m_CurrentHeldItemData = newItemToEquip;
            if (m_CurrentHeldItemData != null)
            {
                m_CurrentHandObject = Instantiate(m_CurrentHeldItemData.WorldPrefab, m_HandPosition);
                m_CurrentHandObject.transform.localPosition = Vector3.zero;
                m_CurrentHandObject.transform.localRotation = Quaternion.identity;
                var renderer = m_CurrentHandObject.GetComponentInChildren<Renderer>();
                if (renderer != null) renderer.material.color = m_CurrentHeldItemData.ItemColor;
                if (InteractionDetector.Instance != null)
                    InteractionDetector.Instance.ShowMessage($"{m_CurrentHeldItemData.ItemName} Equipped");
            }
            else
            {
                 if (InteractionDetector.Instance != null)
                    InteractionDetector.Instance.ShowMessage("Unequipped");
            }

            UpdateUI();
        }

        /// <summary>
        /// Removes the currently held item from the hand.
        /// </summary>
        public void RemoveHeldItem()
        {
            if (m_CurrentHandObject != null) Destroy(m_CurrentHandObject);
            m_CurrentHeldItemData = null;
        }

        /// <summary>
        /// Updates the inventory UI to reflect the current items.
        /// </summary>
        private void UpdateUI()
        {
            for (int i = 0; i < m_SlotImages.Length; i++)
            {
                if (m_InventorySlots[i] != null)
                {
                    m_SlotImages[i].sprite = m_InventorySlots[i].Icon;
                    m_SlotImages[i].color = m_FullSlotColor;
                }
                else
                {
                    m_SlotImages[i].sprite = null;
                    m_SlotImages[i].color = m_EmptySlotColor;
                }
            }
        }
        #endregion
    }
}