using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerController pControl;

	private float baseSpeed;
	private Animator anim;
    void Start(){
        pControl = GetComponentInParent<PlayerController>();
		baseSpeed = pControl.speed;
		anim = gameObject.GetComponentInParent<Animator>();
		anim.SetBool("Team", pControl.team);
    }

	// Update is called once per frame
	void Update() {
		SetPlayerAngle();

		// glue = .2 multiplier;
		float move = (pControl.speed / baseSpeed) * pControl.GetMoveVector().normalized.magnitude;
		anim.SetFloat("Speed", move);
		if (pControl.GetMoveVector().magnitude <= 0.1f) {
			anim.SetBool("IsWalk", false);
		} else { anim.SetBool("IsWalk", true); }
	}

	void SetPlayerAngle() {
		float angle = 0;

		Vector2 lookVector;


		//If the player is "Aiming" use Aim values
		if (pControl.GetAimVector() != Vector2.zero) {
			lookVector = pControl.GetAimVector();

		} else {
			lookVector = pControl.GetMoveVector();
			
		}
		lookVector = new Vector2(-lookVector.y, lookVector.x);
		if (lookVector != Vector2.zero) {
			if (Mathf.Abs(lookVector.x) > Mathf.Abs(lookVector.y)) {
				// use X-
				if (lookVector.x > 0) { angle = 0; } else { angle = 180; }
			} else {
				if (lookVector.y > 0) { angle = 90; } else { angle = 270; }
			}
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
	}
}
