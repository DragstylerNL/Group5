using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    private bool tap, swipeUp, swipeDown, swipeLeft, swipeRight;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;
    [SerializeField]
    private float swipeDeadzone;

    public Action OnSwipeUp;
    public Action OnSwipeDown;
    public Action OnSwipeLeft;
    public Action OnSwipeRight;

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }




    void Update()
    {
        //resets input variables before taking new inputs
        ResetInput();

        CheckMouseInput();

        CheckMobileInput();

        CalcDirection();

        HandleInput();

    }

    private void CheckMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDraging = true;
            startTouch = Input.mousePosition;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
    }

    private void CheckMobileInput()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
    }

    private void CalcDirection()
    {
        // Calculate the distance
        swipeDelta = Vector2.zero;
        // Player touches the screen
        if (isDraging)
        {

            if (Input.touchCount > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;

            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        // Deadzone in pixels
        if (swipeDelta.magnitude > swipeDeadzone)
        {
            // Which direction are we swiping in?
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            // we only want one boolean to be true out of x and y, so the biggest deviation from zero wins
            if (Mathf.Abs(x) <= Mathf.Abs(y) )
            {

                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }
            }
            else
            {

                if (x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }

            }
            Reset();
        }
    }

    private void HandleInput()
    {
        if (swipeUp)
        {
            Debug.Log("up");
            OnSwipeUp?.Invoke();
        }

        if (swipeDown)
        {
            Debug.Log("down");
            OnSwipeDown?.Invoke();
        }

        if (swipeLeft)
        {
            Debug.Log("Left");
            OnSwipeLeft?.Invoke();
        }

        if (swipeRight)
        {
            Debug.Log("Right");
            OnSwipeRight?.Invoke();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

    private void ResetInput()
    {
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;
    }

} 