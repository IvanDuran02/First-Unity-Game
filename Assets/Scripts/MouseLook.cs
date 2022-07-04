using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{   
    public float mouseSensitivity = 1000f;

    public Transform playerBody;

    public PlayerHP MyPlayer;

    private bool isCursorLocked = true;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
       float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
       float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90f); // Stops you from being able to look up or down more than 90 degrees

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); 

        playerBody.Rotate(Vector3.up * mouseX);  

        if (MyPlayer.hp < 0)
        {
            mouseSensitivity = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(isCursorLocked == true)
            {   
                isCursorLocked = false;
                Cursor.lockState = CursorLockMode.None; 
            } else { 
                isCursorLocked = true;
                Cursor.lockState = CursorLockMode.Locked;
                }
        } 
    }
}
