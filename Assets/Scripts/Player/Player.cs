using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float index; //What player is this(1-4)?
    public bool team; //0 = blue; 1 = red
    public GameObject onHand;
    public Vector2 aim;

    [SerializeField] private Transform itemHold;

    protected void UseItem(){
        if (onHand != null){
            onHand.GetComponent<Item>().DoFunction(aim);
            Destroy(onHand);
        }
    }

    public void DropItem(Vector2 throwVector){
        if (onHand != null)
        {
            Debug.Log("I'm dropping the item");
            //Spawn item in world
            GameObject item = onHand.gameObject;
            //Remove item from hand
            item.transform.SetParent(null);
            //Get rid of item in inventory
            onHand = null;
            //"Throw" item away
            item.GetComponent<Rigidbody2D>().AddForce(throwVector);
            //Add "spin" to item
            item.GetComponent<Rigidbody2D>().AddTorque(2, ForceMode2D.Impulse);
        }
    }

    protected void PickupItem(GameObject item){
        Debug.Log("PickupItem()");

        onHand = item;


        item.transform.parent = itemHold;
        item.transform.position = itemHold.position;
    }
}
