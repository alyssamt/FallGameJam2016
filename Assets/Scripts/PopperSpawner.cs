using UnityEngine;
using System.Collections;

public class PopperSpawner : MonoBehaviour {

    public GameObject popper;
    public GameObject confetti;
    public Transform confSpawn;
    public float intervals = 4.0f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("spawn", 1, intervals);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Spawn()
    {
        GameObject newPop;
        float randomX = Random.Range(0.0f, 1.0f);

        if(randomX <= 1.0f)
        {
            newPop = (GameObject)Instantiate(popper, new Vector3(0, Random.Range(0.0f, 1.0f), 0), Quaternion.identity);
        } else
        {
            newPop = (GameObject)Instantiate(popper, new Vector3(1, Random.Range(0.0f, 1.0f), 0), Quaternion.identity);
        }

        newPop.GetComponent<Popper>().confetti = this.confetti;
        newPop.GetComponent<Popper>().confSpawn = this.confSpawn;
    }
}
