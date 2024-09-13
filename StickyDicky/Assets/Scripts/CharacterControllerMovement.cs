using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private CharacterController controller;
    private Vector3 velocity;
    private float currentSpeed;

    // For walking animation
    public Animator animator;

    // Bool for triggering finish animation
    private bool reachedFinish = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Movement input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // Set current speed for animation
        currentSpeed = move.magnitude * speed;
        animator.SetFloat("speed", currentSpeed);

        
        // Trigger animation finish
        if (reachedFinish)
        {
            animator.SetBool("reachedFinish", true); // Set the bool in the animator to true when the finish is reached
        }
    }

    // Detect collision Finish
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Finnish"))
        {
            reachedFinish = true; // Change the bool when touching the Finish object
        }
    }
}
