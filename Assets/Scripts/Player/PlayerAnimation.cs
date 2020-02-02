using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerController pControl;

    void Start(){
        pControl = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerAngle();
    }

    void SetPlayerAngle(){
        float angle = 0;

        Vector2 lookVector;


        //If the player is "Aiming" use Aim values
        if (pControl.GetAimAngle() != Vector2.zero){
            lookVector = pControl.GetAimAngle();
        } else{
            lookVector = pControl.GetMoveVector();
        }


        if (Mathf.Abs(lookVector.x) > Mathf.Abs(lookVector.y))
        {
            // use X-
            if (lookVector.x > 0) { angle = 0; } else { angle = 180; }
        }
        else
        {
            if (lookVector.y > 0) { angle = 90; } else { angle = 270; }
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
