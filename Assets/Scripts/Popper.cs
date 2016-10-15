using UnityEngine;
using System.Collections;

public class Popper : MonoBehaviour {

    public GameObject confetti;
    public Transform confSpawn;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 5; i++)
        {
            GameObject newConf = (GameObject) Instantiate(confetti, confSpawn.position, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
    }
    
}
