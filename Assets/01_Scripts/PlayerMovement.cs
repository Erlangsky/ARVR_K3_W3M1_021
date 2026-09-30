using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5.0f;
    public float gravity = -9.81f;
    public float mouseSensitivity = 500.0f;

    private Vector3 velocity;
    private float xRotation = 0f;
    private Transform cameraTransform;

    void Start()
    {
        // Mengunci kursor di tengah layar agar kamera mudah diputar
        Cursor.lockState = CursorLockMode.Locked;

        // Mencari kamera utama di child Player
        if (Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        // 1. KONTROL KAMERA (Rotasi Mouse)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Mencegah kepala berputar balik

        if (cameraTransform != null)
        {
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
        transform.Rotate(Vector3.up * mouseX);

        // 2. KONTROL PERGERAKAN (Tombol WASD / Arrow Keys)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // 3. GRAVITASI SEDERHANA
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}