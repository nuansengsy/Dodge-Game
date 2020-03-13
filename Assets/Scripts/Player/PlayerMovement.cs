using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float forwardSpeed = 0;
    public float moveStep;
    public float timeToMove;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool swiped;
    private float deadZoneRadius = 2f;

    private bool rightSwiped;
    private bool leftSwiped;

    private float perc = 0f;
    private Vector3 newPos;
    private float startX;
    private float endX;
    private float currentX;

    private float timeStartedLerping;
    private float timeSinceLerping;

    private int currentLane;
    private bool isMovable;
    private bool canBeSideMoved;

    private void Start()
    {
        startX = transform.position.x;
        newPos.y = 5.5f;
        newPos.z = -58f;
        EventsMananger.GameStart += StartMove;
        EventsMananger.GameOver += StopMove;

        EventsMananger.GameResume += ResumeMove;
    }

    private void Update()
    {
        newPos.z += forwardSpeed * Time.deltaTime;
        newPos.x = currentX;
        transform.position = newPos;

        if (canBeSideMoved)
        {

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
                Debug.Log("Began");
                swiped = false;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && !swiped)
            {
                Touch touch = Input.GetTouch(0);

                if ((startTouchPosition - touch.position).magnitude > deadZoneRadius)
                {

                    endTouchPosition = touch.position;

                    if (endTouchPosition.x < startTouchPosition.x && canBeSideMoved && isMovable)
                    {
                        Debug.Log("swiped Left");
                        leftSwiped = true;
                        canBeSideMoved = false;
                        swiped = true;
                        StartCoroutine(Move());
                    }

                    if (endTouchPosition.x > startTouchPosition.x && canBeSideMoved && isMovable)
                    {
                        Debug.Log("swiped Right");
                        rightSwiped = true;
                        canBeSideMoved = false;
                        swiped = true;
                        StartCoroutine(Move());
                    }
                }
            }

        }

    }

    IEnumerator Move()
    {
        if (rightSwiped)
        {

            if (currentLane < 2)
            {
                startX = transform.position.x;
                endX = startX + moveStep;
                timeStartedLerping = Time.time;
                canBeSideMoved = false;

                while (perc < 1)
                {
                    timeSinceLerping = Time.time - timeStartedLerping;
                    perc = timeSinceLerping / timeToMove;
                    currentX = Mathf.Lerp(startX, endX, perc);
                    yield return null;
                }

                perc = 0;
                currentLane++;

            }

            rightSwiped = false;
            canBeSideMoved = true;
            StopCoroutine(Move());


        }

        if (leftSwiped)
        {

            if (currentLane > 0)
            {
                startX = transform.position.x;
                endX = startX - moveStep;
                timeStartedLerping = Time.time;
                canBeSideMoved = false;

                while (perc < 1)
                {
                    timeSinceLerping = Time.time - timeStartedLerping;
                    perc = timeSinceLerping / timeToMove;
                    currentX = Mathf.Lerp(startX, endX, perc);
                    yield return null;
                }

                perc = 0;
                currentLane--;

            }

            leftSwiped = false;
            canBeSideMoved = true;
            StopCoroutine(Move());

        }

    }

    void StartMove()
    {
        currentLane = 1;
        isMovable = true;
        canBeSideMoved = true;
        forwardSpeed = 18f;
        EventsMananger.GameStart -= StartMove;
    }

    public void ResumeMove()
    {
        isMovable = true;
        canBeSideMoved = true;
        forwardSpeed = 18f;
        EventsMananger.GameResume -= ResumeMove;

        //EventsMananger.GameOver += StopMove;

    }

    public void StopMove()
    {
        forwardSpeed = 0f;
        canBeSideMoved = false;
        isMovable = false;
        StopCoroutine(Move());
        //EventsMananger.GameOver -= StopMove;
    }

}

