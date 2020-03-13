using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    private TrailRenderer tr;
    void Start()
    {
        tr = GetComponent<TrailRenderer>();
        tr.enabled = false;
        EventsMananger.GameStart += TurnOnTrail;
    }

    void TurnOnTrail()
    {
        tr.enabled = true;
        EventsMananger.GameStart -= TurnOnTrail;
    }

}
