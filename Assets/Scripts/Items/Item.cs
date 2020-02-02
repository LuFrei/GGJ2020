using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{
    public Rigidbody2D rb2D;
    public int pointValue;

    private void Start(){
        rb2D = GetComponent<Rigidbody2D>();
    }

    public virtual void DoFunction() { }
}
