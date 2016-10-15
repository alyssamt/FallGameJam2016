using UnityEngine;
using System.Collections;

public class HammerSpawn : MonoBehaviour {
	public Transform center;
	public GameObject prefab;
	public float maxSpawnRateInSeconds = 5f;
	
	// Use this for initialization
	void Start () {
		Invoke("SpawnEnemy", maxSpawnRateInSeconds);
		
		//increase spawn rate every 30 seconds
		InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = center.position;
	}
	
	//function to spawn an enemy
	void SpawnEnemy()
	{
		//instantiate an enemy
		GameObject anEnemy = (GameObject)Instantiate(prefab);
		anEnemy.transform.position = new Vector2 (Random.Range (transform.position.x-1, transform.position.x+1), Random.Range (transform.position.y-1, transform.position.y+1));
		anEnemy.GetComponent<Rigidbody2D> ().velocity = Random.insideUnitCircle * 4;
		
		//schedule when to spawn next enemy
		ScheduleNextEnemySpawn();
	}
	
	void ScheduleNextEnemySpawn()
	{
		float spawnInNSeconds;
		
		if (maxSpawnRateInSeconds > 1f)
			//pick a number between 1 and maxSpawnRateInSeconds
			spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
		
		else
			spawnInNSeconds = 1f;
		
		Invoke("SpawnEnemy", spawnInNSeconds);
	}
	
	//function to increase the difficulty of the game
	void IncreaseSpawnRate()
	{
		if (maxSpawnRateInSeconds > 1f)
			maxSpawnRateInSeconds--;
		
		if (maxSpawnRateInSeconds == 1f)
			CancelInvoke("IncreaseSpawnRate");
	}

	public void StopSpawn()
	{
		CancelInvoke ("SpawnEnemy");
	}

}

