using UnityEngine;
using System.Collections;

public class RocketSpawner : MonoBehaviour {

    public GameObject RocketGO; //this is our enemy prefab
    public float maxSpawnRateInSeconds = 5f;
	// Use this for initialization
	void Start () {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        //increase spawn rate every 30 seconds
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //function to spawn an enemy
    void SpawnEnemy()
    {
        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //instantiate an enemy
        GameObject anEnemy = (GameObject)Instantiate(RocketGO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y+3.5f);

        //schedule when to spawn next enemy
        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        if (maxSpawnRateInSeconds > 1f)
        {
            //pick a number between 1 and maxSpawnRateInSeconds
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);

        }
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
}

