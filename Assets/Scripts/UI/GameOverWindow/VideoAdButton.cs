using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class VideoAdButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI videoAdText;
    void Start()
    {
        StartBouncing();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SoundController.SharedInstance.PlaySound("ClickSound");
        iTween.Stop(gameObject);
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    void StartBouncing()
    {
        iTween.ScaleFrom(gameObject,
        iTween.Hash("x", 1.1f, "y", 1.1f, "delay", 0f, "time", 1.2f, "looptype", "loop"));
    }

}
