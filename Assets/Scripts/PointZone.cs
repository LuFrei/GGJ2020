using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointZone : MonoBehaviour
{
    [SerializeField] private Building building;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            //Get item from player's hand
            GameObject item = collision.gameObject.GetComponent<Player>().onHand;
            //Check player onhand, and apply to building
            if (item != null){
                building.pointValue += item.GetComponent<Item>().pointValue;
                Destroy(item);
            }
        }
    }
}
