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

	[SerializeField] private int gameState; //0 = Active; 1 = End 

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
				Debug.Log("On end state");
				if (Input.GetButtonDown("P1A")){
					Debug.Log("Scene shoudl restart to main menu, now");
					SceneManager.LoadScene(0);
				}
				return;
		}
		

		
	}


	void EndGame(){
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
		while (Time.timeScale > 0.0001){
			Time.timeScale -= Time.deltaTime * 0.2f;
			Debug.Log($"Time slowing by: {Time.timeScale}");
			yield return null;
		}
		Time.timeScale = 0;
		Debug.Log("Im out!");
		gameState = 1;

	}

	//Restart game
	void Restart(){
		SceneManager.LoadScene(0);
	}
}
