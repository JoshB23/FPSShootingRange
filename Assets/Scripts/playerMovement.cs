using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;

    float originalHeight;
    public float reducedHeight;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDist = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        originalHeight = controller.height;
    }

    void Update()
    {
        //is player on the ground?
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        //input x & z
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        //using CharacterController to move player x & z
        controller.Move(move * speed * Time.deltaTime);

        //jump function
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //applying gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
            crouch();
        else if (Input.GetKeyUp(KeyCode.LeftControl))
            GoUp();
    }
    //reduce height
    void crouch()
    {
        controller.height = reducedHeight;
    }
    //reset height
    void GoUp()
    {
        controller.height = originalHeight;
    }
}
