using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glue : Item
{
    [SerializeField] private GameObject activeGlue;

    public override void DoFunction(){
        Instantiate(activeGlue,);
    }
}
