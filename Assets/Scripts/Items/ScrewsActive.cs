using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewsActive : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<Player>().DropItem(Vector2.zero);
            Destroy(gameObject);
        }
    }
}
