using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{
	
    private void Update(){

		if (Input.GetButtonDown($"P{index}Use") && onHand != null){
			Debug.Log("I'm using Item");
			UseItem();
			onHand = null;
		}
		
		if (Input.GetButtonDown($"P{index}B") && onHand != null){
			DropItem(GetAimVector());
		}

		aim = Aim(GetMoveVector(), GetAimVector());
	}

	private void FixedUpdate(){
		Move(GetMoveVector());
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

	private void OnTriggerStay2D(Collider2D collision)
	{
		Debug.Log($"the Player is in the Trigger of {collision.gameObject.name}");
		if (collision.gameObject.tag == "Item" && Input.GetButtonDown($"P{index}A") && onHand == null)
		{
			Debug.Log("I SHOULD pick up this item");
			PickupItem(collision.gameObject);
		}
	}
}


