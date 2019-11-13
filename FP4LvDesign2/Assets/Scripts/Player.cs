using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController myController;
    public float speed = 12.0f;

    public Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isGrounded;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
      
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement ()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f; 
        }

        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movement = transform.right * xMov + transform.forward * zMov;

        myController.Move(movement * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        myController.Move(velocity * Time.deltaTime);
        
    }

}
