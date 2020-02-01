using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{

    private void Update(){
        Move(GetMoveInput());
    }

    Vector2 GetMoveInput(){
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        return new Vector2(horizontal, vertical);
    }

    void Move(Vector2 moveVector){
        transform.Translate(moveVector * Time.deltaTime);
    }


}
