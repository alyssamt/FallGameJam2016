using UnityEngine;
using System.Collections;

public class HammerScript : MonoBehaviour {

    GameManager gm;
	HammerSpawn spawnScript;
	public float level;
	float speed = 2f;

	// Use this for initialization
	void Awake () {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		spawnScript = GameObject.Find ("HammerSpawner").GetComponent<HammerSpawn> ();
	}

	void Start () {
	}
	
		
	// Update is called once per frame
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
        /*if (GetComponent<Rigidbody2D>().velocity == new Vector2(0,0))
        {
            Destroy(gameObject);
        }*/
        
	}
			

	/*
	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.name == "Player") {
			coll.GetComponent<PlayerMovement> ().enabled = false;
			Debug.Log ("YOU WERE HIT BY HAMMER");
			gameObject.SetActive (false);
            gm.GameOver();
		}	

	}
    */
}

