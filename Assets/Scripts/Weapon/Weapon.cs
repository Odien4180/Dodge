using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface AutoWeapon
{
    void AutoTrigger();
}

public interface TriggerWeapon
{
    void ManualTrigger();
}

[System.Serializable]
public class Weapon : MonoBehaviour
{
    public int maxBulletCount = 100;
    protected int currentBulletCount;
    public float maxCoolTime = 0.5f;
    protected float currentCoolTime;
    protected float aimAngle;
    public int rank;

    protected bool onWeapon = false;

    public void ActivateWeapon()
    {
        onWeapon = true;

        currentCoolTime = maxCoolTime;
        currentBulletCount = maxBulletCount;
    }
    public void DeactiveWeapon()
    {
        onWeapon = false;

        currentCoolTime = maxCoolTime;
        currentBulletCount = maxBulletCount;
    }

    public void SetAimAngle(float aimAngle)
    {
        this.aimAngle = aimAngle;
    }
}
