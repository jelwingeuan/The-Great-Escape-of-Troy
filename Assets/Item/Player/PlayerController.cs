using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    public float walkSpeed = 3.5f;
    public float sprintSpeed = 5.5f;
    public float crouchSpeed = 2.0f;
    public float gravity = -18f;

    [Header("Crouch")]
    public float standingHeight = 1.8f;
    public float crouchHeight = 1.0f;
    public Transform cameraPivot;

    private CharacterController cc;
    private Vector3 velocity;
    private bool isCrouching;

    public bool IsCrouching => isCrouching;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
        cc.height = standingHeight;
    }

    void Update()
    {
        HandleMove();
        HandleCrouch();
        ApplyGravity();
    }

    void HandleMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 move = (transform.right * x + transform.forward * z).normalized;

        bool sprint = Input.GetKey(KeyCode.LeftShift) && !isCrouching;
        float speed = isCrouching ? crouchSpeed : (sprint ? sprintSpeed : walkSpeed);

        cc.Move(move * speed * Time.deltaTime);
    }

    void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching;
            cc.height = isCrouching ? crouchHeight : standingHeight;

            if (cameraPivot != null)
            {
                Vector3 p = cameraPivot.localPosition;
                p.y = isCrouching ? 0.6f : 0.9f;
                cameraPivot.localPosition = p;
            }
        }
    }

    void ApplyGravity()
    {
        if (cc.isGrounded && velocity.y < 0) velocity.y = -2f;
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
    }
}
