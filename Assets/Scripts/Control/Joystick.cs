using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class Joystick : MonoBehaviour, Touchable
{
    private RectTransform rt;

    [SerializeField]
    private GameObject ball;
    private RectTransform ballRt;

    private float stickRange;

    public bool onTouch;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        ballRt = ball.GetComponent<RectTransform>();

        stickRange = rt.sizeDelta.x * rt.localScale.x / 2 - ballRt.sizeDelta.x * ballRt.localScale.x / 2;

        onTouch = false;
    }

    public float JoystickAngle()
    {
        return IMath.GetAngleFromPosition(ballRt.localPosition.x, ballRt.localPosition.y);
    }

    public void Touch(Vector2 touchPoint)
    {
        onTouch = true;

        if (touchPoint.magnitude > stickRange)
        {
            touchPoint = touchPoint / touchPoint.magnitude * stickRange;
        }
        ballRt.localPosition = touchPoint;
    }

    public void StopTouch()
    {
        onTouch = false;
        ballRt.localPosition = Vector2.zero;
    }
}
