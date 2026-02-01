using UnityEngine;
using DG.Tweening;
using LuduArts.InteractionSystem.Core;

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
        [SerializeField] private string m_KeyIDRequired = "";

        [Header("References")]
        [SerializeField] private Transform m_DoorVisual;
        
        private bool m_IsOpen = false;
        private Quaternion m_ClosedRotation;
        private bool m_IsAnimating;
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

        #region IInteractable Implementation

        public string DisplayName => m_DoorName;
        public string ActionPrompt
        {
            get
            {
                if (m_IsLocked) return "Locked - Key Required";
                return m_IsOpen ? "Press E to Close" : "Press E to Open";
            }
        }
        public float HoldDuration => 0f;

        public bool Interact(GameObject interactor)
        {
            if (m_IsAnimating) return false;
            if (m_IsLocked)
            {
                Debug.Log("Door is locked! Key required.");
                return false; 
            }

            ToggleDoor();
            return true;
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
        /// Locks or unlocks the door.
        /// </summary>
        public void SetLockState(bool isLocked)
        {
            m_IsLocked = isLocked;
        }

        #endregion
    }
}