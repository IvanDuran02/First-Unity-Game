using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

        public GameObject winText;
        public PlayerHP MyPlayer; 

        float time;
        float timeDelay;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        timeDelay = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && MyPlayer.hp > 0)
        {
            winText.SetActive(true);
            time += 1f * Time.deltaTime;
            if (time >= timeDelay)
            {
            SceneManager.LoadScene("Level2"); // goes to scene 2
            }
        }
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {   
        if (hit.gameObject.tag == ("Enemy"))
        {
            Destroy(hit.gameObject);
            MyPlayer.hp -= 49;
            System.Console.WriteLine("Damage taken.");
        }
    }
}
