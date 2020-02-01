using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Item
{
    public override void DoFunction(){
        Debug.Log("Hammer function called from Item!!");
    }
}
