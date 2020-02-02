using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
	private List<GameObject> spawnPoints; //go through list
	private bool switchSides = false;

	private float timer = 0;

	public List<GameObject> objects; // stuff to spawn. Double up to create 

	// Start is called before the first frame update
	void Start() {
		// randomize objects, spawn point order
		spawnPoints = new List<GameObject>();
		GameObject[] tempSpawn = GameObject.FindGameObjectsWithTag("SpawnPoint");
		spawnPoints.Add(tempSpawn[0]);
		for(int i = 1; i<tempSpawn.Length; i++) {
			spawnPoints.Insert(Random.Range(0, spawnPoints.Count-1),tempSpawn[i]);
		}

		List<GameObject> tempObject = new List<GameObject>();
		tempObject.Add(objects[0]);
		for(int i = 1; i<objects.Count; i++) {
			tempObject.Insert(Random.Range(0,tempObject.Count-1), objects[i]);
		}
		objects = tempObject;

		// preliminary round of spawning!  spawn objects, a few on each side.


	}
	private void FixedUpdate() {
		timer -= Time.fixedDeltaTime;
		if(timer <= 0) {
			timer += Random.Range(1f, 5f); // Add seconds till next spawn.
			SpawnObject();

		}
	}

	void SpawnObject() {
		// spawn object at next point	
		Vector3 point = spawnPoints[0].transform.position;
		if (switchSides) {
			Vector3 dir = point;
			dir = Quaternion.Euler(0, 0, 180) * dir;
			point = dir + Vector3.zero;

			///https://answers.unity.com/questions/532297/rotate-a-vector-around-a-certain-point.html
			switchSides = false;
			
		} else { switchSides = true; }

		Instantiate(objects[0], point, Quaternion.identity);
		// shuffle point and object down list 

		int i = Random.Range((int)spawnPoints.Count / 2, spawnPoints.Count);
		spawnPoints.Insert(i, spawnPoints[0]);
		spawnPoints.RemoveAt(0);

		i = Random.Range((int)objects.Count / 2, objects.Count);
		objects.Insert(i, objects[0]);
		objects.RemoveAt(0);

	}













	[SerializeField] private Building blueBuilding;
	[SerializeField] private Building redBuilding;
	public bool blueWins;
	public bool redWins;

	// Update is called once per frame
	void Update()
    {
        if(blueBuilding.pointValue >= 100){
			blueWins = true;
		}
		if(redBuilding.pointValue >= 100)
		{
			redWins = true;
		}
    }



}
