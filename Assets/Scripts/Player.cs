using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float sprintSpeed = 2f;

    private InputSystem_Actions controls;
    private InteractableItem currentItem;

    private Rigidbody rb;
    private bool isGrounded;

    private Vector2 moveInput;
    private Vector3 moveDirection;
    public Transform cam;
    private float currentSpeed;

    private void Awake()
    {
        controls = new InputSystem_Actions();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable() => controls.Player.Enable();
    private void OnDisable() => controls.Player.Disable();

    private void Update()
    {
        moveInput = controls.Player.Move.ReadValue<Vector2>();

        float jump = controls.Player.Jump.ReadValue<float>();
        float sprint = controls.Player.Sprint.ReadValue<float>();
        bool interactPressed = controls.Player.Interact.WasPressedThisFrame();
        
        currentSpeed = speed;
        if (sprint > 0.5f)
        {
            currentSpeed = sprintSpeed;
        }
        
        if (jump > 0.5f && isGrounded)
        {
            float jumpVelocity = Mathf.Sqrt(2f * Physics.gravity.magnitude * jumpHeight);
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpVelocity, rb.linearVelocity.z);
        }
        
        if (interactPressed && currentItem != null)
        {
            currentItem.Interact();
            currentItem = null;
        }
    }

    private void FixedUpdate()
    {
        Vector3 forward = cam.forward;
        Vector3 right = cam.right;
        
        forward.y = 0f;
        right.y = 0f;
        
        forward.Normalize();
        right.Normalize();
        
        moveDirection = forward * moveInput.y + right * moveInput.x;
        
        Vector3 targetVelocity = moveDirection * currentSpeed;
        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<InteractableItem>(out var item))
        {
            currentItem = item;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<InteractableItem>(out var item))
        {
            if (currentItem == item)
            {
                currentItem = null;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}