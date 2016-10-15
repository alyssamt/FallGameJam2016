using UnityEngine;
using System.Collections;

public class LightningSpawner : MonoBehaviour
{

    public GameObject lightning_bolt; //this is our object prefab
    public float maxSpawnRateInSeconds = 5f;
    public Transform center;
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
        //GameObject aBolt = (GameObject)Instantiate(lightning_bolt, center.position, Space.World);
        //aBolt.GetComponent<BGDancer>().center = this.center;

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

