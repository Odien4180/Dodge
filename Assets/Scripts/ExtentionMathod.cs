using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

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

    public static Vector3 SmoothStep(Vector3 startPosition, Vector3 targetPosition, float time)
    {
        return new Vector3(
            Mathf.SmoothStep(startPosition.x, targetPosition.x, time),
            Mathf.SmoothStep(startPosition.y, targetPosition.y, time),
            Mathf.SmoothStep(startPosition.z, targetPosition.z, time)
        );
    }
}

public static class IDebug
{
    private static void Log(string log, LogType logtype = LogType.Log)
    {
#if UNITY_EDITOR
        switch(logtype)
        {
            case LogType.Log:
                Debug.Log(log);
                break;
            case LogType.Warning:
                Debug.LogWarning(log);
                break;
            case LogType.Error:
                Debug.LogError(log);
                break;
        }
#endif
    }
    public static void Log(string log)
    {
        Log(log, LogType.Log);
    }

    public static void Log(params string[] logs)
    {
        Log(IString.Append(logs), LogType.Log);
    }


    public static void LogWarning(string log)
    {
        Log(log, LogType.Warning);
    }

    public static void LogWarning(params string[] logs)
    {
        Log(IString.Append(logs), LogType.Warning);
    }

    public static void LogError(string log)
    {
        Log(log, LogType.Error);
    }

    public static void LogError(params string[] logs)
    {
        Log(IString.Append(logs), LogType.Error);
    }
}

public static class IString
{
    public static StringBuilder stringBuilder;

    private static void InitializeStringBuilder()
    {
        if (stringBuilder == null)
        {
            stringBuilder = new StringBuilder();
        }
        else
        {
            stringBuilder.Clear();
        }
    }

    public static string Append(params string[] texts)
    {

        InitializeStringBuilder();

        for (int i = 0; i < texts.Length; ++i)
        {
            stringBuilder.Append(texts[i]);
        }

        return stringBuilder.ToString();        
    }
}