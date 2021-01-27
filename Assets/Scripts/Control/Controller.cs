using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controller : SingletonClass<Controller>
{
    public Controlable controlTarget;
    public GameObject controlTargetObj;

    public Joystick rightJoystick;
    public Joystick leftJoystick;

    private void Update()
    {
        if (leftJoystick.onTouch)
            controlTarget.ControlMove(leftJoystick.JoystickAngle());

        if (rightJoystick.onTouch)
            controlTarget.ControlAim(rightJoystick.JoystickAngle());
    }

    public void SetControlTarget(Controlable target, GameObject targetObj)
    {
        controlTarget = target;
        controlTargetObj = targetObj;
    }
}
