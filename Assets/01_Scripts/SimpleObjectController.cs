using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Pengaturan Gerak (WASD)")]
    public float moveSpeed = 5f;
    public float gravity = -9.81f; 
    public float jumpHeight = 1.5f;

    [Header("Pengaturan Kamera (Mouse)")]
    public Transform cameraTransform; 
    public float mouseSensitivity = 100f;
    public float maxLookAngle = 90f; 

    private CharacterController characterController;
    private Vector3 velocity; 
    private float xRotation = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (cameraTransform == null)
        {
            Camera cam = GetComponentInChildren<Camera>();
            if (cam != null) cameraTransform = cam.transform;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxLookAngle, maxLookAngle);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);


        float x = Input.GetAxis("Horizontal"); // A / D
        float z = Input.GetAxis("Vertical");   // W / S

        Vector3 move = transform.right * x + transform.forward * z;

        if (characterController != null)
        {
            characterController.Move(move * moveSpeed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && characterController.isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }
        else
        {
            transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}