using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController3D : MonoBehaviour
{
    [Header("Player Data")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody myRBD;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundLayer;
    private Vector2 movement;
    private bool isJump = false;
    private bool isGrounded = true;

    private void FixedUpdate()
    {
        CheckGround();
        ApplyPhysics();
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            isJump = true;
        }
    }
    private void ApplyPhysics()
    {
        myRBD.velocity = new Vector3(movement.x * speed, myRBD.velocity.y, movement.y * speed);

        if(isJump)
        {
            myRBD.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isJump = false;
        }
    }
    private void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, groundLayer);
    }
}
