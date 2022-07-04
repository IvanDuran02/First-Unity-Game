using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Text hpText; // public if you want to drag your text object in there manually
    public float hp = 100f;
    public GameObject deadText;


    void Start()
    {
    }


    void Update()
    {
        hpText.text = "Health: " + hp.ToString(); // make it a string to output to the Text object

        if (hp <= 0)
        {
            deadText.SetActive(true);
        }
    }
}
