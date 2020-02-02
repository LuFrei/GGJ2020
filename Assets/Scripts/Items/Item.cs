using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{
    public Rigidbody2D rb2D;
    public int pointValue;
    public int type;

    private void Start(){
        rb2D = GetComponent<Rigidbody2D>();
    }

    public virtual void DoFunction(Vector2 aim) { }
}
