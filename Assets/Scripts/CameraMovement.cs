using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public float sens = 10f;
    
    public Transform playerBody;
    public Transform visualMesh;
    public Transform mainCamera;

    float xRotation; 
    float yRotation; 

    public InputActionAsset PlayerControls;
    private InputAction lookAction;
    Vector2 lookInput;
    
    public float distance = 5f; 
    public float height = 2f;   
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        lookAction = PlayerControls.FindActionMap("Player").FindAction("Look");
        lookAction.Enable();
    }

    void LateUpdate()
    {
        lookInput = lookAction.ReadValue<Vector2>();

        xRotation += lookInput.x * sens * Time.deltaTime;
        yRotation -= lookInput.y * sens * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, -80f, 80f); 
        
        Quaternion yaw = Quaternion.Euler(0, xRotation, 0);
        
        if (visualMesh != null) 
        {
            visualMesh.rotation = yaw;
        }
        
        Vector3 targetPosition = playerBody.position;
        Vector3 offset = yaw * new Vector3(0, 0, -distance);
        
        mainCamera.position = targetPosition + offset + new Vector3(0, height, 0);
        mainCamera.rotation = Quaternion.Euler(yRotation, xRotation, 0);
    }   
}