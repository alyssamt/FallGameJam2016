using UnityEngine;
using System.Collections;

public class LightningSpawner : MonoBehaviour
{

    public GameObject lightning_bolt; //this is our object prefab
    public GameObject red_lightning;
    public float maxSpawnRateInSeconds = 5f;
    public Transform center;
    public GameManager gm;


    // Use this for initialization
    void Start()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //function to spawn an enemy
    void SpawnEnemy()
    {
        
        //instantiate an enemy
        GameObject aBolt = (GameObject)Instantiate(lightning_bolt);
        aBolt.transform.position = center.transform.position;

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
}

