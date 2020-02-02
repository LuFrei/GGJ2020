using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	[SerializeField] private Building blueBuilding;
	[SerializeField] private Building redBuilding;
	[SerializeField] private GameObject blueWinBanner;
	[SerializeField] private GameObject redWinBanner;

	private int gameState; //0 = Active; 1 = End 
	public bool blueWins;
	public bool redWins;

	private float endWait = 2;

	// Update is called once per frame
	void Update()
	{
		switch (gameState)
		{
			case 0:
				if (blueBuilding.pointValue >= 100 || redBuilding.pointValue >= 100)					
					EndGame();
				return;
			case 1:
				if (Input.GetButtonDown("P1A"))
					SceneManager.LoadScene(0);
				return;
		}
		

		
	}


	void EndGame(){
		//pause game
		Time.timeScale = 0;
		//check and display winner
		if(blueBuilding.pointValue >= 100){
			blueWinBanner.SetActive(true);
		} else{
			redWinBanner.SetActive(true);
		}
		//wait seconds
		StartCoroutine(countdown(endWait));
		//set game to wait for input to restart
	}

	IEnumerator countdown(float timer){
		while (timer > 0){
			timer -= Time.deltaTime;
			yield return null;
		}
		gameState = 1;
	}

	//Restart game
	void Restart(){
		SceneManager.LoadScene(0);
	}
}
