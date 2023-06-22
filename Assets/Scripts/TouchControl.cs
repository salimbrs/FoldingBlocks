using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    Vector2 StartTouchPos;
    Vector2 currentPos;
    

    public RotationController controller;

  public  float swipeRange;

    bool stopTouch = false;

    void Update()
    {
        Swipe();
    }

    public void Swipe()
    {
        if (controller.work==true)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                StartTouchPos = Input.GetTouch(0).position;
             
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                currentPos = Input.GetTouch(0).position;
                Vector2 Distance = currentPos - StartTouchPos;
               

                if (!stopTouch)
                {
                    if (Mathf.Abs(Distance.x) > Mathf.Abs(Distance.y))
                    {
                        if (Distance.x < -swipeRange)
                        {
                            controller.MoveParents(0);
                            stopTouch = true;
                        }
                        else if (Distance.x > swipeRange)
                        {
                            controller.MoveParents(1);
                            stopTouch = true;
                        }
                    }
                    else
                    {
                        if (Distance.y > swipeRange)
                        {
                            controller.MoveParents(2);
                            stopTouch = true;
                        }
                        else if (Distance.y < -swipeRange)
                        {
                            controller.MoveParents(3);
                            stopTouch = true;
                        }
                    }



                }
                stopTouch = false;
            }
        }

       
    }
}
