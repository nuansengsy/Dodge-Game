using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToMoveSideways : MonoBehaviour
{
    public GameObject parent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("triggered");
            parent.GetComponent<MoveSideways>().StopBouncing();
            parent.GetComponent<MoveSideways>().StartMove();

        }
           
    }
}
