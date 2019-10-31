using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static bool isAlive;
    public static int lifesCount;
    public Text displayLifesCount;

    void Start()
    {
        isAlive = true;
        lifesCount = 3;
        displayLifesCount.text = "Lifes " + lifesCount;
    }

    void Update()
    {
        //displayLifesCount.text = "Lifes " + lifesCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Heart")
        {
            lifesCount++;
            displayLifesCount.text = "Lifes " + lifesCount;
        }

        if (other.gameObject.tag == "Obstacle")
        {
            lifesCount--;
            displayLifesCount.text = "Lifes " + lifesCount;
            if(lifesCount <= 0)
            {
                isAlive = false;
            }
        }
    }
}
