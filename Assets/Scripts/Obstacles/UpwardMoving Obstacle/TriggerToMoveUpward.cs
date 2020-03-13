using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToMoveUpward : MonoBehaviour
{
    public GameObject parent;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("triggered");
            parent.GetComponent<MoveUpward>().StartMove();
        }

    }
}
