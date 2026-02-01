using UnityEngine;
using DG.Tweening;
using LuduArts.InteractionSystem.Core;

namespace LuduArts.InteractionSystem.Interactables
{
    /// <summary>
    /// It manages the logic of opening and closing the ballot boxes.
    /// Requires holding to open (Hold) and pressing to close (Instant).
    /// </summary>
    public class ChestController : MonoBehaviour, IInteractable
    {
        #region Fields

        private const float k_OpenDuration = 3f;
        private const float k_AnimDuration = 1.5f;

        // Serialized private fields
        [Header("Settings")]
        [SerializeField] private string m_ChestName = "Old Chest";
        [SerializeField] private float m_OpenAngle = -100f;

        [Header("References")]
        [SerializeField] private Transform m_LidPivot;
        [SerializeField] private Transform m_LockVisual;

        private bool m_IsOpen = false;
        private bool m_IsAnimating = false;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (m_LidPivot == null)
            {
                Debug.LogError($"{name}: Lid Pivot atanmamış!");
            }
        }

        private void OnDestroy()
        {
            m_LidPivot.DOKill();
            if (m_LockVisual != null) m_LockVisual.DOKill();
        }

        #endregion

        #region IInteractable Implementation

        public string DisplayName => m_ChestName;

        public string ActionPrompt
        {
            get
            {
                if (m_IsAnimating) return "";
                
                return m_IsOpen ? "Press E to Close" : "Hold E to Open";
            }
        }

        public float HoldDuration
        {
            get
            {
                return m_IsOpen ? 0f : k_OpenDuration;
            }
        }

        public bool Interact(GameObject interactor)
        {
            if (m_IsAnimating) return false;

            if (m_IsOpen)
            {
                CloseChest();
            }
            else
            {
                OpenChest();
            }

            return true;
        }

        #endregion

        #region Methods

        private void OpenChest()
        {
            m_IsAnimating = true;
            m_IsOpen = true;
            if (m_LockVisual != null)
            {
                m_LockVisual.DOPunchRotation(new Vector3(0, 0, 15), 0.5f);
            }
            m_LidPivot.DOLocalRotate(new Vector3(m_OpenAngle, 0, 0), k_AnimDuration)
                .SetEase(Ease.OutBounce)
                .OnComplete(() => m_IsAnimating = false);
        }

        private void CloseChest()
        {
            m_IsAnimating = true;
            m_IsOpen = false;
            m_LidPivot.DOLocalRotate(Vector3.zero, k_AnimDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(() => m_IsAnimating = false);
        }

        #endregion
    }
}