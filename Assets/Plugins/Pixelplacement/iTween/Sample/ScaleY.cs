using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleY : MonoBehaviour
{
    void Start()
    {
        iTween.PunchScale(gameObject, iTween.Hash("y", 1.5, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
    }
}
