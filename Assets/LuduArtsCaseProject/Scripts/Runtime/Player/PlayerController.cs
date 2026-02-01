using UnityEngine;

namespace LuduArts.InteractionSystem.Player
{
    /// <summary>
    /// Basic first-person player controller handling movement and looking around.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        #region Fields
        private const float k_LookLimit = 85f;
        [Header("Movement Settings")]
        [SerializeField] private float m_MoveSpeed = 5f;
        [SerializeField] private float m_Gravity = -9.81f;
        [SerializeField] private float m_JumpHeight = 1.5f;

        [Header("Look Settings")]
        [SerializeField] private float m_MouseSensitivity = 2f;
        [SerializeField] private Transform m_CameraTransform;

        private CharacterController m_CharacterController;
        private float m_VerticalVelocity;
        private float m_CameraPitch;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            HandleMovement();
            HandleRotation();
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Initializes the player controller by setting up the CharacterController and camera.
        /// </summary>
        private void Initialize()
        {
            m_CharacterController = GetComponent<CharacterController>();

            if (m_CameraTransform == null)
            {
                Debug.LogError($"{name}: Camera Transform atanmamış! Lütfen Inspector'dan atayın.");
                enabled = false;
                return;
            }
            Camera.main.transform.SetParent(m_CameraTransform);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        /// <summary>
        /// Handles player movement including walking and jumping.
        /// </summary>
        private void HandleMovement()
        {
            if (m_CharacterController.isGrounded && m_VerticalVelocity < 0)
            {
                m_VerticalVelocity = -2f;
            }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            m_CharacterController.Move(move * m_MoveSpeed * Time.deltaTime);
            if (Input.GetButtonDown("Jump") && m_CharacterController.isGrounded)
            {
                m_VerticalVelocity = Mathf.Sqrt(m_JumpHeight * -2f * m_Gravity);
            }
            m_VerticalVelocity += m_Gravity * Time.deltaTime;
            m_CharacterController.Move(Vector3.up * m_VerticalVelocity * Time.deltaTime);
        }
        /// <summary>
        /// Handles player rotation based on mouse movement.
        /// </summary>
        private void HandleRotation()
        {
            float mouseX = Input.GetAxis("Mouse X") * m_MouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * m_MouseSensitivity;
            m_CameraPitch -= mouseY;
            m_CameraPitch = Mathf.Clamp(m_CameraPitch, -k_LookLimit, k_LookLimit);

            if (m_CameraTransform != null)
            {
                m_CameraTransform.localRotation = Quaternion.Euler(m_CameraPitch, 0f, 0f);
            }
            transform.Rotate(Vector3.up * mouseX);
        }
        #endregion
    }
}