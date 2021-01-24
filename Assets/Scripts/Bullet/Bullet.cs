using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float time;
    private float angle;

    private Vector2 vec;
    
    private float reg;

    private bool active = false;


    [Range(0.0f, 1000.0f)]
    public float power = 1f;
    [Range(0.0f, 1.0f)]
    public float regcons = 0.1f;


    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Shoot(45);
        }

        if (!active) return;

        reg += Time.deltaTime * regcons;
        
        //vec = IMath.GetPositionFromAngle(angle += Time.deltaTime * 360);
        
        Vector2 dis = vec * power * Time.deltaTime * (1 - reg);

        //if (dis.x <= 0 && dis.y <= 0)
        //{
        //    return;
        //}

        transform.Translate(dis);
    }

    public void Shoot(float angle)
    {
        active = true;

        time = 0f;
        reg = 0f;

        this.angle = angle;

        vec = IMath.GetPositionFromAngle(angle);

    }

    

}
