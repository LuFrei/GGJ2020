using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screws : Item
{
    public override void DoFunction(Vector2 aim)
    {
        Debug.Log("Screw function called from Item!!");
    }
}
