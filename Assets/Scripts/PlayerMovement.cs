using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public CharacterController controller;
    // Start is called before the first frame update

    Vector3 velocity;

    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    bool isGrounded;

    public PlayerHP MyPlayer;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MyPlayer.hp < 0)
        {
            speed = 0;
            jumpHeight = 0f;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            speed *= 1.5f;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            speed = 10f;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // checks if you are ground level

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // pulls you back down if in the air
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if (move.magnitude > 1)
        {
            move/=move.magnitude;
        }

        controller.Move(move * speed * Time.deltaTime); // adding deltaTime makes it frame rate independant.

        if(Input.GetButtonDown("Jump") && isGrounded) // if you press SpaceBar and are on the ground you jump
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            // SceneManager.LoadScene("Level2"); // goes to scene 2
            SceneManager.LoadScene("Game"); // this is to restart
        }

    }
}
