using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 300f;     
    [SerializeField] private float mouseSensitivity = 200f;

    private CharacterController controller;
    private float rotationY;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleRotation();
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontal = -Input.GetAxisRaw("Horizontal");
        float vertical   = -Input.GetAxisRaw("Vertical");

        Vector3 move = (transform.right * horizontal + transform.forward * vertical).normalized;
        controller.Move(move * speed * Time.deltaTime);
    }

    private void HandleRotation()
    {

        float mouseX = -Input.GetAxis("Mouse X");

        rotationY += mouseX * mouseSensitivity * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }
}
