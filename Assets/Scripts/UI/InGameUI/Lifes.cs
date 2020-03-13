using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifes : MonoBehaviour
{
    public Text displayLifesCount;
    public Image heartIcon;
    void Start()
    {
        EventsMananger.GameStart += ShowLifesNumber;
        EventsMananger.EarnReward += ShowLifesNumber;

        EventsMananger.GameOver += HideLifesNumber;
    }

    void ShowLifesNumber()
    {
        displayLifesCount.enabled = true;
        heartIcon.enabled = true;
    }

    void HideLifesNumber()
    {
        displayLifesCount.enabled = false;
        heartIcon.enabled = false;
    }
}
