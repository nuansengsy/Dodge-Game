using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelocateMovableObstacle : MonoBehaviour
{
    public GameObject parentObstacle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("triggered");
            parentObstacle.GetComponent<AdditionalData>().Movee();
        }
           
    }
}
