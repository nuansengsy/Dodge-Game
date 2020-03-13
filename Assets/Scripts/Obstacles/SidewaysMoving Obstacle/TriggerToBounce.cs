using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToBounce : MonoBehaviour
{
    public GameObject parent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            parent.GetComponent<MoveSideways>().StartBouncing();
        }

    }
}
