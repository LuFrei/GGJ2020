using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

	void Move(Vector2 moveVector) {
		//transform.Translate(moveVector * Time.deltaTime);
		transform.position = transform.position + (new Vector3 (moveVector.x,moveVector.y,0) * Time.deltaTime);

		float angle = 0;
		if (Mathf.Abs(moveVector.x) > Mathf.Abs(moveVector.y)) {
			// use X-
			if (moveVector.x > 0) { angle = 0; } else { angle = 180; }
		} else {
			if (moveVector.y > 0) { angle = 90; } else { angle = 270; }
		}
		transform.rotation = Quaternion.Euler(0, 0, angle);
		}
		

}


