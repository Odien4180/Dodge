using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IMath
{
    public static Vector2 GetPositionFromAngle(float angle)
    {
        float theta = Mathf.PI * angle / 180;

        return new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
    }

    public static float GetAngleFromPosition(Vector2 position)
    {
        return GetAngleFromPosition(position.x, position.y);
    }

    public static float GetAngleFromPosition(float x, float y)
    {
        float rad = Mathf.Atan2(y, x);

        return rad * 180 / Mathf.PI;
    }    
}