using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalData : MonoBehaviour
{
    public string objectType;
    public bool isMovable;
    public Vector3 endPosition;

    private float timeStartedLerping;
    private float timeSinceLerping;
    public float timeToMove;
    private Vector3 currentPos;
    private float perc = 0f;

    private bool moved = false;

    public void Movee()
    {
        StartCoroutine(MoveObstacle());
    }

    IEnumerator MoveObstacle()
    {
        if (!moved)
        {
            currentPos = transform.localPosition;
            timeStartedLerping = Time.time;
            while (perc < 1)
            {
                timeSinceLerping = Time.time - timeStartedLerping;
                perc = timeSinceLerping / timeToMove;
                transform.localPosition = Vector3.Lerp(currentPos, endPosition, perc);
                yield return null;
            }
        }
        perc = 0f;
        moved = false;
        
    }


}
