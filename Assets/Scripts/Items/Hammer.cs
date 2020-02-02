using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Item
{
    [SerializeField] private GameObject activeHammer;

    public override void DoFunction(Vector2 aim){
        float angle = Vector2.Angle(new Vector2(0.0f, 1.0f), aim);
        Debug.Log($"hammer angle: {angle}");
        if (aim.x < 0.0f)
        {
            
            angle = angle + 360;
        }
        if(aim.x > 0.0f)
        {
            angle = -angle;
        }

        Instantiate(activeHammer, gameObject.transform.position + new Vector3(0, 10, 0), Quaternion.Euler(0, 0, angle));
    }
}
