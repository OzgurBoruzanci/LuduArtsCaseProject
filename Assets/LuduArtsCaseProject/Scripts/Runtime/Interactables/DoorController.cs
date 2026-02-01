using UnityEngine;
using DG.Tweening;
using LuduArts.InteractionSystem.Core;
using LuduArts.InteractionSystem.UI;
using LuduArts.InteractionSystem.Data;
using LuduArts.InteractionSystem.Player;

namespace LuduArts.InteractionSystem.Interactables
{
    /// <summary>
    /// It controls the door's opening/closing and locking functions.
    /// </summary>
    public class DoorController : MonoBehaviour, IInteractable
    {
        #region Fields
        private const float k_AnimationDuration = 0.5f;
        [Header("Interaction Settings")]
        [SerializeField] private string m_DoorName = "Wooden Door";
        [Header("Settings")]
        [SerializeField] private float m_OpenAngle = 45f;
        [SerializeField] private bool m_IsLocked = false;
        [SerializeField] private GameObject m_KeyTarget;
        [SerializeField] private ItemData m_Key;

        [Header("References")]
        [SerializeField] private Transform m_DoorVisual;

        private bool m_IsOpen = false;
        private Quaternion m_ClosedRotation;
        private bool m_IsAnimating;
        #endregion

        #region IInteractable Implementation

        public string DisplayName => m_DoorName;
        public string ActionPrompt
        {
            get
            {
                if (m_IsLocked) return $"Locked - {m_Key.ItemName} Required";
                return m_IsOpen ? "Press E to Close" : "Press E to Open";
            }
        }
        public float HoldDuration => 0f;

        public bool Interact(GameObject interactor)
        {
            if (m_IsAnimating) return false;
            if (m_IsLocked)
            {
                InventoryManager inventory = interactor.GetComponent<InventoryManager>();
                if (inventory != null && inventory.HeldItem != null)
                {
                    if (inventory.HeldItem.ItemID == m_Key.ItemID)
                    {
                        UnlockSequence(inventory);
                        return true;
                    }
                    else
                    {
                        Debug.Log("Wrong Key!");
                        string wrongKeyName = inventory.HeldItem.ItemName;
                        InteractionDetector.Instance.ShowMessage($"{wrongKeyName} is not the correct key!");
                        return false;
                    }
                }
                Debug.Log("Locked - Key Required");
                return false;
            }
            ToggleDoor();
            return true;
        }

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (m_DoorVisual == null) m_DoorVisual = transform;
            m_ClosedRotation = m_DoorVisual.localRotation;
        }

        private void OnDestroy()
        {
            m_DoorVisual.DOKill();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Toggles the door state (Open <-> Closed).
        /// </summary>
        private void ToggleDoor()
        {
            m_IsAnimating = true;
            m_IsOpen = !m_IsOpen;
            Quaternion targetRotation = m_IsOpen
                ? m_ClosedRotation * Quaternion.Euler(0f, m_OpenAngle, 0f)
                : m_ClosedRotation;
            m_DoorVisual.DOLocalRotateQuaternion(targetRotation, k_AnimationDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(() => m_IsAnimating = false);
        }

        /// <summary>
        /// Handles the unlock sequence when the correct key is used.
        /// </summary>
        private void UnlockSequence(InventoryManager inventory)
        {
            m_IsAnimating = true;
            GameObject keyObj = inventory.HandObject;
            keyObj.transform.SetParent(null);
            Vector3 targetPos = m_KeyTarget.transform.position;
            keyObj.transform.rotation = Quaternion.Euler(0, 0, 90);
            keyObj.transform.DOMove(targetPos, 1f).SetEase(Ease.InBack).OnComplete(() =>
            {
                Destroy(keyObj);
                inventory.RemoveHeldItem();
                m_IsLocked = false;
                m_IsAnimating = false;
                ToggleDoor();
            });
        }
        /// <summary>
        /// Locks or unlocks the door.
        /// </summary>
        public void SetLockState(bool isLocked)
        {
            m_IsLocked = isLocked;
        }

        #endregion
    }
}