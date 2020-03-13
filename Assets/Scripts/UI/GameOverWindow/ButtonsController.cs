using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonsController : MonoBehaviour
{
    public GameObject restartButton;
    private RectTransform restartButtonTransform;

    public GameObject resumeButton;
    private CanvasGroup resumeCanvGroup;

    public GameObject videoADButton;
    private CanvasGroup videoADCanvGroup;

    private void Start()
    {
        restartButtonTransform = restartButton.GetComponent<RectTransform>();
        videoADCanvGroup = videoADButton.GetComponent<CanvasGroup>();
        resumeCanvGroup = resumeButton.GetComponent<CanvasGroup>();

        EventsMananger.EarnReward += ShowResumeButton;
    }

    public void ShowAdButton()
    {
        restartButtonTransform.anchoredPosition = new Vector3(0, 0, 0);
        videoADButton.GetComponent<Image>().enabled = true;
        videoADButton.GetComponent<Button>().enabled = true;
        videoADButton.GetComponent<VideoAdButton>().videoAdText.enabled = true;
        videoADCanvGroup.blocksRaycasts = true;
    }

    public void ShowResumeButton()
    {
        restartButtonTransform.anchoredPosition = new Vector3(0, 0, 0);
        videoADButton.SetActive(false);

        resumeButton.GetComponent<Image>().enabled = true;
        resumeButton.GetComponent<Button>().enabled = true;
        resumeButton.GetComponent<ResumeGameButton>().resumeGameText.enabled = true;
        resumeCanvGroup.blocksRaycasts = true;

        EventsMananger.EarnReward -= ShowResumeButton;
    }

    public void ShowRestartOnly()
    {
        resumeButton.SetActive(false);
        restartButtonTransform.anchoredPosition = new Vector3(0, 130, 0);
    }
}
