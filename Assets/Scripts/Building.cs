using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
	public int pointValue; //from 0-100
	Animator anim;

	private void Start() {
		anim = gameObject.GetComponent<Animator>();

	}
	//anim.SetFloat("Progress",pointValue/1000);

}
