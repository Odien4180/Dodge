using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : Weapon, AutoWeapon
{
    private void Start()
    {
        ActivateWeapon();
    }

    private void Update()
    {
        if (!onWeapon) return;

        currentCoolTime -= Time.deltaTime;


        if (currentCoolTime < 0 && currentBulletCount > 0)
        {
            AutoTrigger();

            currentCoolTime = maxCoolTime + currentCoolTime;
        }

    }


    public void AutoTrigger()
    {
        currentBulletCount -= 1;
        
        GameObject go = Instantiate(ObjectManager.GetInstance.GetPrefab("Dod"), transform.position, Quaternion.identity, transform);
        Bullet bullet = go.GetComponent<Bullet>();

        bullet.Shoot(aimAngle);

        CameraManager.GetInstance.GetCamera("BloomCamera");
    }

}
