using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{
    public Rigidbody2D rb2D;
    public int pointValue;
    public int type; //0 = hammer; 1 = glue; 2 = screws;

    private void Start(){
        rb2D = GetComponent<Rigidbody2D>();
    }

    public virtual void DoFunction(Vector2 aim) { }
}
