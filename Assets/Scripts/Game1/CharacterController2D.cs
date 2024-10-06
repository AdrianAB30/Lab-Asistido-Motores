using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRbd;
    [SerializeField] private float velocity;
    private Vector2 movement;

    private void Awake()
    {
        myRbd = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        myRbd.velocity = new Vector2(movement.x * velocity, movement.y * velocity);
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
