using UnityEngine;
using System.Collections;

public class RocketSpawner : MonoBehaviour {

    public GameManager gm;
    public GameObject RocketGO; //this is our enemy prefab
    public float maxSpawnRateInSeconds = 5f;
    public float spawnRate = 1f;
    //public bool active;

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        this.enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (this.enabled && !gm.doingSetup)
        {
            spawnRate -= Time.deltaTime;
            if (spawnRate <= 0)
            {
                SpawnEnemy();
                spawnRate = 5f;
            }
        }
    }


    public void BeginSpawning()
    {
        Invoke("SpawnEnemy", 0);

        //increase spawn rate every 30 seconds
        //InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
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
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y + 3.5f);

        //schedule when to spawn next enemy
        //ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        if (!gm.doingSetup)
        {
            /*
            float spawnInNSeconds;

            if (maxSpawnRateInSeconds > 1f)
            {
                //pick a number between 1 and maxSpawnRateInSeconds
                spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);

            }
            else
                spawnInNSeconds = 1f;
                */

            Invoke("SpawnEnemy", Random.Range(1f, maxSpawnRateInSeconds));
        }
    }

    //function to increase the difficulty of the game
    //called from GameManager each level
    public void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;

        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }
}

