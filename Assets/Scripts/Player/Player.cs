﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float index; //What player is this(1-4)?
    public bool team; //0 = blue; 1 = red
    public Item onHand;
    public Vector2 aim;
    protected bool nextToItem;

    protected void UseItem(){
        if (onHand != null)
            onHand.DoFunction(aim);
    }

    protected void DropItem(Vector2 throwVector){
        //Spawn item in world
        Item item = Instantiate(onHand, transform.position, Quaternion.identity);
        //Get rid of item in inventory
        onHand = null;
        //"Throw" item away
        item.rb2D.AddForce(throwVector);
        //Add "spin" to item
        item.rb2D.AddTorque(2, ForceMode2D.Impulse);
    }

    protected void PickupItem(Item item){
        Debug.Log("PickupItem()");
        onHand = new Item item;
        Destroy(item.gameObject);
    }
}
