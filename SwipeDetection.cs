using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    private Vector2 bTouchPos;
    private Vector2 eTouchPos;
    public float distanceToSwipe;
    private bool touchDown;
    private PlayerMovement p_movement;

    [HideInInspector] public Vector2 swipeVector;


    private void Start()
    {
        touchDown = false;
        bTouchPos = new Vector2();
        eTouchPos = new Vector2();
        swipeVector = new Vector2();

        p_movement = gameObject.GetComponent<GameManager>().p_movement;
    }
    void Update()
    {
        if (touchDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            bTouchPos = Input.touches[0].position;
            touchDown = true;
        }

        if (touchDown == true && Input.touches[0].phase == TouchPhase.Ended)
        {
            eTouchPos = Input.touches[0].position;

            if ((bTouchPos - eTouchPos).magnitude > distanceToSwipe)
            {
                SwipeDetected();
            }
            touchDown = false;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            print(swipeVector);
        }
    }

    void SwipeDetected() {

        swipeVector = bTouchPos - eTouchPos;
        //print(swipeVector.magnitude);
        p_movement.swipeVector = -swipeVector;
        p_movement.swiped = true;
    }
}
