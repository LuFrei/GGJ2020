using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glue : Item
{
    [SerializeField] private GameObject activeGlue;

    public override void DoFunction(Vector2 aim){
        Instantiate(activeGlue, gameObject.transform.position + new Vector3(aim.x, aim.y, 0), Quaternion.identity);
    }
}
