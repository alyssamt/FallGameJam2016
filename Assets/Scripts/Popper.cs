using UnityEngine;
using System.Collections;

public class Popper : MonoBehaviour {

    public GameObject confetti;
    public bool left;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 3; i++)
        {
            GameObject newConf = (GameObject) Instantiate(confetti, this.transform.position, Quaternion.identity);
            newConf.GetComponent<Confetti>().left = this.left;
        }
	}
	
	// Update is called once per frame
	void Update () {
    }
    
}
