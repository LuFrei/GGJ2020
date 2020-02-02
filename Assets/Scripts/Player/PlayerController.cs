using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{
	
    private void Update(){

		if (Input.GetButtonDown($"P{index}A")){
			GetPlayerAction();
		}
		
		if (Input.GetButtonDown($"P{index}B") && onHand != null){
			DropItem(GetAimVector());
		}

		aim = Aim(GetMoveVector(), GetAimVector());
	}

	private void FixedUpdate(){
		Move(GetMoveVector());
	}

	//determine whether player will be using or picking up or using item
	private void GetPlayerAction(){
		//if there's something in my hand, use it
		if (onHand != null)
		{
			UseItem();
			onHand = null;
		}
		//check if theres anything to be picked up
		if (nearbyItem != null)
			PickupItem(nearbyItem);
	}

	public Vector2 GetMoveVector(){
        float horizontal = Input.GetAxis("P" + index + "Hoz");
        float vertical = Input.GetAxis("P" + index + "Vert");

        return new Vector2(horizontal, vertical);
    }

	public Vector2 GetAimVector()
	{
		float horizontal = Input.GetAxis("P" + index + "AimHoz");
		float vertical = Input.GetAxis("P" + index + "AimVert") * -1; //for some reason this is flipped on the right stick. -1 to cancel it.

		return new Vector2(horizontal, vertical);
	}

	void Move(Vector2 moveVector) {
		transform.Translate(moveVector * speed * Time.deltaTime);
	}

	public Vector2 Aim(Vector2 moveVector, Vector2 lookVector){
		if(lookVector != Vector2.zero){
			return lookVector;
		}
		return moveVector;
	}

	private void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Item"){
			nearbyItem = collision.gameObject;
		}
	}

	private void OnTriggerExit2D(Collider2D collision){
		if (collision.gameObject == nearbyItem){
			nearbyItem = null;
		}
	}
}


