using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour {

	public Transform prefab; //prefab of enemy in inspector

	public float spawnTime = 2f;
	private float timer = 3f; // start the timer off larger than the required spawn time so a unit spawns immeadately

	//temporarily removed these functions for testing purposes
	//public int spawnCount = 5;
	//private int counter = 0;
	
	// Update is called once per frame
	void Update () {
		if(timer > spawnTime){ //&& counter <= spawnCount)
			Instantiate(prefab, transform.position, transform.rotation);
			timer = 0f;

			//counter++;
		}
		else{
			timer += Time.deltaTime;
		}
	}
}
