using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private InputSystem_Actions controls; 
    
    private void Awake()
    {
        controls = new InputSystem_Actions();
    }

    private void OnEnable() => controls.Player.Enable();
    private void OnDisable() => controls.Player.Disable();
    
    void Update()
    {
        Vector2 input = controls.Player.Move.ReadValue<Vector2>();
        
        Vector3 move = new Vector3(input.x, 0, input.y);
        
        transform.Translate(move * (speed * Time.deltaTime), Space.World);
    }
}
