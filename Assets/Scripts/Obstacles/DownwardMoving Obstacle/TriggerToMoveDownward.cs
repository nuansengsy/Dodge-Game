using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToMoveDownward : MonoBehaviour
{
    public GameObject parent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            parent.GetComponent<MoveDownward>().StartMove();
        }

    }
}
