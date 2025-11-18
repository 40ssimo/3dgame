using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    private InputSystem_Actions _actions;

    private void Awake()
    {
        _actions = new InputSystem_Actions();
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

        var direction = new Vector3();
        direction.x = _input.x;
        direction.z = _input.y;
        
        Debug.Log(direction);

        transform.position += direction.normalized * _movementSpeed * Time.deltaTime;
    }

    private void Jump()
    {
        Debug.Log("Jump");
    }
}
