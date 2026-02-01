using UnityEngine;
using UnityEngine.UI; // UI Image kontrolü için gerekli
using LuduArts.InteractionSystem.Core;

namespace LuduArts.InteractionSystem.Player
{
    /// <summary>
    /// It detects interactive objects in the direction the player is looking and manages the input.
    /// </summary>
    public class InteractionDetector : MonoBehaviour
    {
        #region Fields
        private const string k_InteractInput = "Interact"; 

        [Header("Detection Settings")]
        [SerializeField] private float m_InteractionRange = 3f;
        [SerializeField] private LayerMask m_InteractableLayer;
        [SerializeField] private Transform m_CameraTransform;

        [Header("UI Feedback")]
        [SerializeField] private Image m_ReticleImage;
        [SerializeField] private Image m_ProgressBarImage;
        [SerializeField] private TMPro.TextMeshProUGUI m_ObjectNameText;
        [SerializeField] private TMPro.TextMeshProUGUI m_ActionPromptText;
        
        [Header("Reticle Settings")]
        [SerializeField] private Color m_DefaultReticleColor = Color.white;
        [SerializeField] private Color m_HoverReticleColor = Color.green;
        [SerializeField] private float m_HoverScale = 1.2f;

        private IInteractable m_CurrentInteractable;
        private Vector3 m_OriginalReticleScale;
        private float m_CurrentHoldTime;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            DetectInteractable();
            HandleInput();
            UpdateUI();
        }

        #endregion

        #region Methods
        /// <summary>
        /// Initializes the interaction detector by setting up the camera and reticle.
        /// </summary>
        private void Initialize()
        {
            if (m_CameraTransform == null)
            {
                m_CameraTransform = Camera.main.transform;
                Debug.LogWarning($"{name}: Camera Transform atanmamış, MainCamera kullanılıyor.");
            }

            if (m_ReticleImage != null)
            {
                m_OriginalReticleScale = m_ReticleImage.rectTransform.localScale;
                m_ReticleImage.color = m_DefaultReticleColor;
            }
            else
            {
                Debug.LogError($"{name}: Reticle Image (UI) atanmamış! Görsel geri bildirim çalışmayacak.");
            }
            ClearUIText();
        }

        /// <summary>
        /// Performs a raycast each frame to detect interactive objects.
        /// </summary>
        private void DetectInteractable()
        {
            Ray ray = new Ray(m_CameraTransform.position, m_CameraTransform.forward);
            RaycastHit hit;

            bool hitSomething = Physics.Raycast(ray, out hit, m_InteractionRange, m_InteractableLayer);

            if (hitSomething)
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                if (interactable != null)
                {
                    if (m_CurrentInteractable != interactable)
                    {
                        m_CurrentInteractable = interactable;
                        m_CurrentHoldTime = 0f; // Hedef değişince süreyi sıfırla
                        OnTargetHoverStart();
                    }
                    return;
                }
            }

            // Boşa bakıyorsak
            if (m_CurrentInteractable != null)
            {
                m_CurrentInteractable = null;
                m_CurrentHoldTime = 0f;
                OnTargetHoverEnd();
            }
        }

        /// <summary>
        /// Checks if the interaction key is pressed.
        /// </summary>
        private void HandleInput()
        {
            if (m_CurrentInteractable == null) return;

            // INSTANT INTERACTION (Süre 0 ise)
            if (m_CurrentInteractable.HoldDuration <= 0f)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    m_CurrentInteractable.Interact(gameObject);
                    UpdateUI(); // Yazıları anında güncelle (Open -> Close değişimi için)
                }
                return;
            }

            // HOLD INTERACTION (Süre > 0 ise)
            if (Input.GetKey(KeyCode.E))
            {
                m_CurrentHoldTime += Time.deltaTime;

                // Süre doldu mu?
                if (m_CurrentHoldTime >= m_CurrentInteractable.HoldDuration)
                {
                    m_CurrentInteractable.Interact(gameObject);
                    m_CurrentHoldTime = 0f; // İşlem bitince sıfırla
                    UpdateUI();
                }
            }
            else
            {
                // Tuşu bırakırsa süreyi sıfırla
                m_CurrentHoldTime = 0f;
            }
        }
        private void UpdateUI()
        {
            if (m_CurrentInteractable != null)
            {
                if (m_ObjectNameText != null) m_ObjectNameText.text = m_CurrentInteractable.DisplayName;
                if (m_ActionPromptText != null) m_ActionPromptText.text = m_CurrentInteractable.ActionPrompt;

                UpdateProgressBar();
            }
        }

        private void UpdateProgressBar()
        {
            if (m_ProgressBarImage == null) return;

            // Eğer instant ise veya tuşa basılmıyorsa barı gizle
            if (m_CurrentInteractable.HoldDuration <= 0f || m_CurrentHoldTime <= 0f)
            {
                m_ProgressBarImage.gameObject.SetActive(false);
                m_ProgressBarImage.fillAmount = 0f;
                return;
            }

            float progress = m_CurrentHoldTime / m_CurrentInteractable.HoldDuration;

            // %15 KURALI: Progress 0.15'ten küçükse barı gösterme
            if (progress < 0.15f)
            {
                m_ProgressBarImage.gameObject.SetActive(false);
            }
            else
            {
                m_ProgressBarImage.gameObject.SetActive(true);
                m_ProgressBarImage.fillAmount = progress;
            }
        }
        /// <summary>
        /// Provides UI feedback when an object is targeted.
        /// </summary>
        private void OnTargetHoverStart()
        {
            if (m_ReticleImage != null)
            {
                m_ReticleImage.color = m_HoverReticleColor;
                m_ReticleImage.rectTransform.localScale = m_OriginalReticleScale * m_HoverScale;
            }
            UpdateUI();
        }

        private void OnTargetHoverEnd()
        {
            if (m_ReticleImage != null)
            {
                m_ReticleImage.color = m_DefaultReticleColor;
                m_ReticleImage.rectTransform.localScale = m_OriginalReticleScale;
            }
            
            if (m_ProgressBarImage != null)
            {
                m_ProgressBarImage.fillAmount = 0f;
                m_ProgressBarImage.gameObject.SetActive(false);
            }
            
            ClearUIText();
        }

        private void ClearUIText()
        {
            if (m_ObjectNameText != null) m_ObjectNameText.text = "";
            if (m_ActionPromptText != null) m_ActionPromptText.text = "";
        }
        #endregion
    }
}