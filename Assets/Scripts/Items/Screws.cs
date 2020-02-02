using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screws : Item
{
    [SerializeField] private GameObject activeScrews;

    public override void DoFunction(Vector2 aim)
    {
        Instantiate(activeScrews, gameObject.transform.position, Quaternion.identity);
    }
}
