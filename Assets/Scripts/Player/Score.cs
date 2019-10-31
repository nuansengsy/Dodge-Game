using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public static int score;
    public static int bestScore;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        score = 0;
        InvokeRepeating("UpdateScore", 0.4f, 0.4f);
    }

    // Update is called once per frame
    private void Update()
    {
        scoreText.text = score.ToString();
        if (!PlayerHealth.isAlive)
        {
            CancelInvoke("UpdateScore");
            if(score > PlayerPrefs.GetInt("BestScore", 0))
            {
                PlayerPrefs.SetInt("BestScore", score);
            }
            Debug.Log("BestScore = " + PlayerPrefs.GetInt("BestScore", 0));
        }
    }

    void UpdateScore()
    {
        score += 1;
    }

}
