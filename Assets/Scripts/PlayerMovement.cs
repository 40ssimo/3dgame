using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _jumpSpeed = 10f;
    
    private InputSystem_Actions _actions;
    private Rigidbody _rb;

    private void Awake()
    {
        _actions = new InputSystem_Actions();
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _actions.Enable();
        _actions.Player.Jump.performed += ctx => { Jump(); };
    }


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 _input = _actions.Player.Move.ReadValue<Vector2>();

        var moveDirection = new Vector3();
        moveDirection.x = _input.x;
        moveDirection.z = _input.y;
        
        Debug.Log(moveDirection);
        Debug.Log(transform.forward.normalized);
        transform.position += moveDirection.normalized * _movementSpeed * Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection.normalized, Time.deltaTime * _movementSpeed);
        // transform.LookAt(transform.position + moveDirection);
    }

    private void Jump()
    {
        _rb.AddForce(new Vector3(0, _jumpSpeed, 0),ForceMode.Impulse);
    }
}
