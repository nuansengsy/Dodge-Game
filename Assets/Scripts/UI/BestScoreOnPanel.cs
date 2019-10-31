using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreOnPanel : MonoBehaviour
{
    public Text bestScorePanel;
    void Start()
    {
        bestScorePanel = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerHealth.isAlive)
        {
            bestScorePanel.text = "Best Score " + PlayerPrefs.GetInt("BestScore", 0).ToString();
        }
    }
}
