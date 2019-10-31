using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreOnPanel : MonoBehaviour
{
    public Text scoreOnPanel;
    void Start()
    {
        scoreOnPanel = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerHealth.isAlive)
        {
            scoreOnPanel.text = "Score " + Score.score.ToString();
        }
    }
}
