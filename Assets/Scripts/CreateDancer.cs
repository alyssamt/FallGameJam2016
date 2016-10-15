using UnityEngine;
using System.Collections;

public class CreateDancer : MonoBehaviour {
    
    public GameObject dancer;
    public Transform center;
    public int spawnMax;
    public GameManager gm;

    void Start()
    {
        float degreesPerSpawn = 360f / ((float)spawnMax);
        for (int i = 0; i < spawnMax; i++)
        {
            Vector3 directionOffset = Quaternion.AngleAxis(degreesPerSpawn * i, Vector3.forward) * Vector2.up * 3;
            GameObject newBG = (GameObject) Instantiate(dancer, center.position + directionOffset, Quaternion.identity);
            newBG.GetComponent<BGDancer>().center = this.center;
            newBG.GetComponent<BGDancer>().gm = this.gm;
        }
    }

    // Increase number of rings as levels go on
 
}
