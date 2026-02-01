using UnityEngine;
using DG.Tweening;
using LuduArts.InteractionSystem.Core;

namespace LuduArts.InteractionSystem.Interactables
{
    /// <summary>
    /// Manages the light switch and its associated light source.
    /// </summary>
    public class LightSwitch : MonoBehaviour, IInteractable
    {
        #region Fields

        [Header("Settings")]
        [SerializeField] private float m_OnRotationZ = -20f;
        [SerializeField] private float m_OffRotationZ = 20f;
        [SerializeField] private bool m_IsOn = false;
        [SerializeField] private string m_DisplayName = "Light Switch";

        [Header("References")]
        [SerializeField] private Transform m_SwitchMesh;
        [SerializeField] private Light m_TargetLight;

        #endregion

        #region IInteractable Implementation

        public string DisplayName => m_DisplayName;
        public string ActionPrompt
        {
            get
            {
                return m_IsOn ? "Press E to Turn Off" : "Press E to Turn On";
            }
        }
        public float HoldDuration => 0f;
        public bool Interact(GameObject interactor)
        {
            m_IsOn = !m_IsOn;
            UpdateState(false);
            return true;
        }

        #endregion
        
        #region Unity Methods

        private void Awake()
        {
            UpdateState(true);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the light and switch mesh state.
        /// </summary>
        /// <param name="instant"></param>
        private void UpdateState(bool instant)
        {
            if (m_TargetLight != null)
            {
                m_TargetLight.enabled = m_IsOn;
            }
            if (m_SwitchMesh != null)
            {
                Vector3 targetEuler = m_SwitchMesh.localEulerAngles;
                targetEuler.z = m_IsOn ? m_OnRotationZ : m_OffRotationZ;

                if (instant)
                {
                    m_SwitchMesh.localEulerAngles = targetEuler;
                }
                else
                {
                    m_SwitchMesh.DOLocalRotate(targetEuler, 0.2f).SetEase(Ease.OutBack);
                }
            }
        }

        #endregion
    }
}