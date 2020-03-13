using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpward : MonoBehaviour
{
    [SerializeField]  private Vector3 moveFromPosition;
    [SerializeField]  private Vector3 moveToPosition;

    private float timeStartedLerping;
    private float timeSinceLerping;
    public float timeToMove;
    private float perc = 0f;

    private bool moved = false;

    public void StartMove()
    {
        StartCoroutine(MoveObstacle());
    }

    IEnumerator MoveObstacle()
    {
        if (!moved)
        {
            timeStartedLerping = Time.time;

            while (perc < 1)
            {
                timeSinceLerping = Time.time - timeStartedLerping;
                perc = timeSinceLerping / timeToMove;
                transform.localPosition = Vector3.Lerp(moveFromPosition, moveToPosition, perc);
                yield return null;
            }
        }
        perc = 0f;
        moved = false;

    }

    private void OnEnable()
    {
        //Set X
        if (GetComponent<AdditionalData>().allocatedPosition.x < 0)
        {
            moveFromPosition.x = (GetComponent<AdditionalData>().allocatedPosition.x * 6) - (1 - (transform.localScale.x / 2));

        }

        if (GetComponent<AdditionalData>().allocatedPosition.x == 0)
        {
            moveFromPosition.x = 0;

        }

        if (GetComponent<AdditionalData>().allocatedPosition.x > 0)
        {
            moveFromPosition.x = (GetComponent<AdditionalData>().allocatedPosition.x * 6) + (1 - (transform.localScale.x / 2));

        }

        //Set Z
        if (GetComponent<AdditionalData>().allocatedPosition.z < 0)
        {
            moveFromPosition.z = (GetComponent<AdditionalData>().allocatedPosition.z * 48) - (1 - (transform.localScale.z / 2));

        }

        if (GetComponent<AdditionalData>().allocatedPosition.z == 0)
        {
            moveFromPosition.z = 0;

        }

        if (GetComponent<AdditionalData>().allocatedPosition.z > 0)
        {
            moveFromPosition.z = (GetComponent<AdditionalData>().allocatedPosition.z * 48) + (1 - (transform.localScale.z / 2));

        }
        //Set Y
        moveFromPosition.y = (10 / 2) / (transform.localScale.y);
        transform.localPosition = moveFromPosition;

        moveToPosition = moveFromPosition;
        moveToPosition.y = (10 / 2) + (transform.localScale.y / 2);

        moved = false;
    }
}
