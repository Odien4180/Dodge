using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICamera : MonoBehaviour
{
    public new Camera camera;

    public bool cameraShake;
    public float cameraShakeTerm;


    public bool smoothStep;

    public float smoothSpeed = 9;
    public float minSmoothSpeed = 1;

    private Vector3 smoothTargetPosition;

    private void Awake()
    {
        camera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        if (camera == null)
        {
            camera = GetComponentInChildren<Camera>();
            if (camera == null)
            {
                IDebug.LogError(gameObject.name, " : Not Exist Camera");

                return;
            }
            else
            {
                IDebug.LogWarning(gameObject.name, " : Camera is Null So Search Camera");
            }
        }

        //카메라 서서히 이동
        if (smoothStep)
        {
            RecalcCameraPosition();
        }
    }

    public void CameraMove(Vector3 targetPosition, bool smoothStep = false)
    {
        this.smoothStep = smoothStep;

        if (!smoothStep)
        {
            smoothTargetPosition = targetPosition;

            transform.localPosition = targetPosition;
        }
        else
        {
            smoothTargetPosition = targetPosition;
        }
    }

    private void RecalcCameraPosition()
    {
        Vector3 vec = smoothTargetPosition - transform.localPosition;
        float distance = vec.magnitude;

        float time = distance / smoothSpeed + 1;

        Vector3 moveVec = vec.normalized * Time.deltaTime * time * time;

        transform.Translate(moveVec);
    }
}
