using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI mainMenuBestScore;

    public Text currentScore;
    public TextMeshProUGUI scoreOnPanel;
    public TextMeshProUGUI bestScoreOnPanel;


    public int score;
    public int bestScore;

    private void Start()
    {
        mainMenuBestScore.text = "BEST SCORE " + PlayerPrefs.GetInt("BestScore", 0).ToString();

        EventsMananger.GameStart += StartScore;
        EventsMananger.GameOver += StopScore;
    }

    // Update is called once per frame
    private void Update()
    {
        currentScore.text = score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TargetObject")
        {
            UpdateScore();
            SoundController.SharedInstance.PlaySound("TargetHitSound");
        }
    }
    void StartScore()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        score = 0;
    }

    public void UpdateScore()
    {
        score += 1;
        currentScore.rectTransform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
        StartCoroutine(ExampleCoroutine());

    }

    public void StopScore() 
    {
        CancelInvoke("UpdateScore");
        if (score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

        scoreOnPanel.text = "Score " + score.ToString();
        bestScoreOnPanel.text = "Best Score " + PlayerPrefs.GetInt("BestScore", 0).ToString();

        EventsMananger.GameOver -= StopScore;
    }

    public void ResumeScore()
    {
        EventsMananger.GameOver += StopScore;
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        currentScore.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

}
