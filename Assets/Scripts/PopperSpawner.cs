using UnityEngine;
using System.Collections;

public class PopperSpawner : MonoBehaviour {

    public GameObject popper;
    public GameObject confetti;
    public float spawnTime = 4.0f;
    public float destoryDelay = 2.0f;

    private     GameObject newPop;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", 2, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(newPop, 2.0f);
	}

    void Spawn()
    {
        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 spawnPoints;
        float randomX = Random.Range(0.0f, 1.0f);

        if (randomX < 0.5)
        {
            spawnPoints = new Vector2(min.x, Random.Range(min.y, max.y));
            newPop = (GameObject)Instantiate(popper, spawnPoints, Quaternion.identity);
            newPop.GetComponent<Popper>().left = true;
        }
        else
        {
            spawnPoints = new Vector2(max.x, Random.Range(min.y, max.y));
            newPop = (GameObject)Instantiate(popper, spawnPoints, Quaternion.AngleAxis(90, Vector3.forward));
            newPop.GetComponent<Popper>().left = false;
        }

        newPop.GetComponent<Popper>().confetti = this.confetti;
    }

    void DelayDestroy()
    {
        
    }
}
