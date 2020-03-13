using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int lifesNumber;
    public Text displayLifesCount;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        lifesNumber = 3;
        displayLifesCount.text = lifesNumber.ToString();

        EventsMananger.EarnReward += PrepareToResumeGame;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "ObstacleObject")
        {
            lifesNumber--;
            //Debug.Log("Lifes -1");
            displayLifesCount.text = lifesNumber.ToString();
            SoundController.SharedInstance.PlaySound("ObstacleHitSound");

            if (lifesNumber <= 0)
            {
                    rend.enabled = false;
                    EventsMananger.SharedInstance.EndGame();
            }
        }

        if (other.gameObject.tag == "ColorChanger")
        {
            ColorManager.SharedInstance.ApplyNewColorSet();
            SoundController.SharedInstance.PlaySound("ColorSwithedSound");
        }

    }

    void PrepareToResumeGame()
    {
        lifesNumber++;
        displayLifesCount.text = lifesNumber.ToString();
        rend.enabled = true;
        EventsMananger.EarnReward -= PrepareToResumeGame;
    }
}
