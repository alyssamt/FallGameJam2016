using UnityEngine;
using System.Collections;

public class HammerScript : MonoBehaviour {

	public float level;
	
	void Update () {

		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //if the enemy went outside the screen on the bottom, then destroy the enemy
        
        if (transform.position.y < min.y || transform.position.x < min.x || transform.position.y > max.y || transform.position.x > max.x)
        {
            Debug.Log("Destroying hammer");
            Destroy(gameObject);
        }

        //if the hammer is stuck inside MC Hammer and not moving, destroy the hammer
        if (GetComponent<Rigidbody2D>().velocity == new Vector2(0,0))
        {
            Destroy(gameObject);
        }
        
	}
}

