using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed;
    public float moveStep;
    public float timeToMove;

    private bool rightKeyPressed;
    private bool leftKeyPressed;

    private float perc = 0f;
    private Vector3 currentPos;
    private Vector3 newPos;

    private float timeStartedLerping;
    private float timeSinceLerping;

    private int currentLane;
    private bool canBeMoved;

    private void Start()
    {
        currentLane = 1;
        canBeMoved = true;
    }

    private void Update()
    {
        transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * forwardSpeed;

        if (canBeMoved)
        {
            if (Input.GetKeyDown(KeyCode.D) && canBeMoved)
            {
                rightKeyPressed = true;
                canBeMoved = false;
                StartCoroutine(Move());
                //Debug.Log("Right Key Pressed");
            }

            if (Input.GetKeyDown(KeyCode.A) && canBeMoved)
            {
                leftKeyPressed = true;
                canBeMoved = false;
                StartCoroutine(Move());
                //Debug.Log("Left Key Pressed");
            }
        }

        if(PlayerHealth.lifesCount == 0)
        {
            forwardSpeed = 0f;
            canBeMoved = false;
        }
    }

    IEnumerator Move()
    {
        if (rightKeyPressed)
        {
           
            if (currentLane < 2)
            {
                currentPos = transform.position;
                newPos = currentPos;
                newPos.x += moveStep;
                timeStartedLerping = Time.time;
                canBeMoved = false;

                while (perc < 1)
                {
                    timeSinceLerping = Time.time - timeStartedLerping;
                    perc = timeSinceLerping / timeToMove;
                    transform.position = Vector3.Lerp(currentPos, newPos, perc);
                    yield return null;
                }

                perc = 0;
                currentLane++;

            }

            rightKeyPressed = false;
            canBeMoved = true;
            StopCoroutine(Move());

        }

        if (leftKeyPressed)
        {

            if(currentLane > 0)
            {
                currentPos = transform.position;
                newPos = currentPos;
                newPos.x -= moveStep;
                timeStartedLerping = Time.time;
                canBeMoved = false;

                while (perc < 1)
                {
                    timeSinceLerping = Time.time - timeStartedLerping;
                    perc = timeSinceLerping / timeToMove;
                    transform.position = Vector3.Lerp(currentPos, newPos, perc);
                    yield return null;
                }

                perc = 0;
                currentLane--;

            }

            leftKeyPressed = false;
            canBeMoved = true;
            StopCoroutine(Move());
        }

    }
}

