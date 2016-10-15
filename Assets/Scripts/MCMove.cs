using UnityEngine;
using System.Collections;



public class MCMove : MonoBehaviour {

    public float maxX = 6.1F;
    public float minX = -6.1F;
    public int moveSpeed = 5;

    public float tChange = 0;
    public float randomX = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // change to random direction at random intervals
        if (Time.time >= tChange)
        {
            randomX = Random.Range(-5.0F, 5.0F); // with float parameters, a random float
                                               // set a random interval between 0.7 and 0.9
            tChange = Time.time + Random.Range(0.7F, 0.9F);
        }
        if (randomX <= 0)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else if (randomX > 0)
        {
            transform.Translate(Vector3.right * moveSpeed* Time.deltaTime);

        }// if object reached any border, revert the appropriate direction
        if (transform.position.x >= maxX || transform.position.x <= minX)
        {
            randomX = -randomX;
        }
        // make sure the position is inside the borders
        //transform.position.x = Mathf.Clamp(transform.position.x, minX, maxX);
    }
}
