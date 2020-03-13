using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsMananger : MonoBehaviour
{
    public static EventsMananger SharedInstance;

    public delegate void OnGameStart();
    public static event OnGameStart GameStart;

    public delegate void OnGameOver();
    public static event OnGameOver GameOver;

    public delegate void OnRewardEarned();
    public static event OnRewardEarned EarnReward;

    public delegate void OnGameResume();
    public static event OnGameResume GameResume;


    void Start()
    {
        SharedInstance = this;
    }

    public void StartGame()
    {
        GameStart();
    }

    public void EndGame()
    {
        GameOver();
    }

    public void Reward()
    {
        EarnReward();
    }

    public void Resume()
    {
        if(GameResume != null)
        {
            GameResume();
        }

    }

    private void OnDestroy()
    {
        EventsMananger.GameStart = null;
        EventsMananger.GameOver = null;
        EventsMananger.EarnReward = null;
        EventsMananger.GameResume = null;
    }
}
