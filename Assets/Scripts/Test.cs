using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{

    public GameObject winText; 

    Rigidbody rb;

    float xInput;
    float zInput;
    
    public float speed; 

    // Start is called before the first frame update
    void Start()
    {   
    //  Destroy(gameObject, 5); // Destroys the object that its attached to after 5 seconds.

        rb = GetComponent<Rigidbody>(); // grabs components from the rigid body.

        GetComponent<Renderer>().material.color = Color.red; // grabs the components rendered material color and changes it to red

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 500);
        }
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        rb.AddForce(xInput * speed, 0, zInput * speed);

        if (Input.GetKeyDown(KeyCode.D)) 
        {
        //    Destroy(gameObject, 3f); // 3f is still seconds but counted as a float.
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
        //    rb.velocity = Vector3.forward * 5f; // moves forward
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level2"); // changes scenes
        }
    }



    private void OnMouseDown()
    {
        Destroy(gameObject); // if clicked on gameObject it will be destroyed.
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") // when object touches another object with enemy tag destroy.
        {
         // Destroy(gameObject); // Destroys gameObject
            Destroy(collision.gameObject); // Destroys Object with enemy tag
            winText.SetActive(true); // sets winText as active to show what it contains.
        }
    }
}
