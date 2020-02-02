using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{
	
    private void Update(){
        Move(GetMoveVector());


		Debug.Log($"Aim Angle: {GetAimAngle()}");
	}

    public Vector2 GetMoveVector(){
        float horizontal = Input.GetAxis("P" + index + "Hoz") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("P" + index + "Vert") * speed * Time.deltaTime;

        return new Vector2(horizontal, vertical);
    }

	public Vector2 GetAimAngle()
	{
		float horizontal = Input.GetAxis("P" + index + "AimHoz");
		float vertical = Input.GetAxis("P" + index + "AimVert");

		return new Vector2(horizontal, vertical);
	}

	void Move(Vector2 moveVector) {
		//transform.Translate(moveVector * Time.deltaTime);
		transform.position += (new Vector3 (moveVector.x,moveVector.y,0) * Time.deltaTime);
	}
}


