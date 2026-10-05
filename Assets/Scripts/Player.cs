using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float sprintSpeed = 2f;
    [SerializeField] private float pickupRadius = 2f;

    private InputSystem_Actions controls;
    private InteractableItem currentItem;
    private Inventory inventory;
    
    private Rigidbody rb;
    private bool isGrounded;

    private void Awake()
    {
        controls = new InputSystem_Actions();
        rb = GetComponent<Rigidbody>();
        inventory = GetComponent<Inventory>();
    }

    private void OnEnable() => controls.Player.Enable();
    private void OnDisable() => controls.Player.Disable();

    private void Update()
    {
        Vector2 input = controls.Player.Move.ReadValue<Vector2>();
        float jump = controls.Player.Jump.ReadValue<float>();
        float sprint = controls.Player.Sprint.ReadValue<float>();
        
        bool interactPressed = controls.Player.Interact.WasPressedThisFrame();
        
        float currentSpeed = speed;
        if (sprint > 0.5f)
        {
            currentSpeed = sprintSpeed;
        }
        
        Vector3 move = new Vector3(input.x, 0f, input.y);
        rb.linearVelocity = new Vector3(move.x * currentSpeed, rb.linearVelocity.y, move.z * currentSpeed);

        if (jump > 0.5f && isGrounded)
        {
            float jumpVelocity = Mathf.Sqrt(2f * Physics.gravity.magnitude * jumpHeight);
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpVelocity, rb.linearVelocity.z);
        }
        
        if (interactPressed && currentItem != null)
        {
            currentItem.Interact(inventory); 
            currentItem = null;
        }
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

    private void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void OnCollisionExit()
    {
        isGrounded = false;
    }
}