using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1000f;
    [SerializeField] private float mouseSensitivity = 200f;

    private float rotationY;

    void Update()
    {
        HandleRotation();
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Move relative to where the player is facing
        Vector3 move = transform.forward * vertical + transform.right * horizontal;
        move.Normalize();

        transform.position += move * speed * Time.deltaTime;
    }

    private void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");

        rotationY += mouseX * mouseSensitivity * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }
}
