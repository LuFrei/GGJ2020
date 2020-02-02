using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{
	
    private void Update(){
        Move(GetMoveVector());

		if (Input.GetAxis($"P{index}A") > 0 && onHand != null){
			UseItem();
			onHand = null;
		}
		
		if (Input.GetAxis($"P{index}B") > 0 && onHand != null){
			DropItem(GetAimAngle());
		}
	}

    public Vector2 GetMoveVector(){
        float horizontal = Input.GetAxis("P" + index + "Hoz") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("P" + index + "Vert") * speed * Time.deltaTime;

        return new Vector2(horizontal, vertical);
    }

	public Vector2 GetAimAngle()
	{
		float horizontal = Input.GetAxis("P" + index + "AimHoz");
		float vertical = Input.GetAxis("P" + index + "AimVert") * -1; //for some reason this is flipped on the right stick. -1 to cancel it.

		return new Vector2(horizontal, vertical);
	}

	void Move(Vector2 moveVector) {
		//transform.Translate(moveVector * Time.deltaTime);
		transform.position += (new Vector3 (moveVector.x,moveVector.y,0) * Time.deltaTime);
	}
}


