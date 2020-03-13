using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    public Text displayCurrentScore;
    void Start()
    {
        EventsMananger.GameStart += ShowScore;
    }

    void ShowScore()
    {
        displayCurrentScore.enabled = true;
    }
}
