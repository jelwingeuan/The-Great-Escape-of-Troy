using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform cameraTransform;
    public float sensitivity = 2.0f;
    public float minPitch = -70f;
    public float maxPitch = 70f;

    private float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mx = Input.GetAxis("Mouse X") * sensitivity;
        float my = Input.GetAxis("Mouse Y") * sensitivity;

        transform.Rotate(Vector3.up * mx);

        pitch -= my;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        if (cameraTransform != null)
            cameraTransform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }
}
