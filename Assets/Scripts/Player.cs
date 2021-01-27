using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Controlable
{
    public float speed = 10;

    public Weapon weapon;

    private void Start()
    {
        Controller.GetInstance.SetControlTarget(this, gameObject);
    }

    public void ControlMove(float angle)
    {
        transform.Translate(IMath.GetPositionFromAngle(angle) * speed * Time.deltaTime);
    }

    public void ControlAim(float direction)
    {
        weapon.SetAimAngle(direction);
    }

    public void ControlFireDirection(float direction)
    {
        
    }

    public void WeaponChange()
    {
        
    }
}
