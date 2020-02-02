using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
	public Sprite[] buildingSteps;
	SpriteRenderer render;
	public int pointValue; //from 0-100

	private void Start() {
		render = GetComponent<SpriteRenderer>();
	}

	private void Update(){
		render.sprite = buildingSteps[pointValue / 10];
	}


}
