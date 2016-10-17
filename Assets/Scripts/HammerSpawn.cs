using UnityEngine;
using System.Collections;

public class HammerSpawn : MonoBehaviour {

    public GameManager gm;
    public GameObject MCHammer;
	public GameObject prefab;

    //public bool active = false;
    public float spawnRate = 1f;

    private int i = 0;
	
	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        MCHammer = GameObject.Find("MC Hammer");
        this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.enabled && !gm.doingSetup)
        {
            spawnRate -= Time.deltaTime;
            if (spawnRate <= 0)
            {
                SpawnEnemy();
                spawnRate = 1f;
            }
        }
    }

    //function to spawn an enemy
    void SpawnEnemy()
    {
        float speed = Random.Range(30, 80);
        GameObject anEnemy = (GameObject)Instantiate(prefab);
        
        switch (i)
        {
            case 0:
                anEnemy.transform.position = new Vector2(MCHammer.transform.position.x - 1, MCHammer.transform.position.y + 1);
                anEnemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1) * speed);
                break;
            case 1:
                anEnemy.transform.position = new Vector2(MCHammer.transform.position.x, MCHammer.transform.position.y + 1);
                anEnemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * speed);
                break;
            case 2:
                anEnemy.transform.position = new Vector2(MCHammer.transform.position.x + 1, MCHammer.transform.position.y + 1);
                anEnemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * speed);
                break;
            case 3:
                anEnemy.transform.position = new Vector2(MCHammer.transform.position.x + 1, MCHammer.transform.position.y);
                anEnemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * speed);
                break;
            case 4:
                anEnemy.transform.position = new Vector2(MCHammer.transform.position.x + 1, MCHammer.transform.position.y-1);
                anEnemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, -1) * speed);
                break;
            case 5:
                anEnemy.transform.position = new Vector2(MCHammer.transform.position.x, MCHammer.transform.position.y - 1);
                anEnemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1) * speed);
                break;
            case 6:
                anEnemy.transform.position = new Vector2(MCHammer.transform.position.x-1, MCHammer.transform.position.y - 1);
                anEnemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, -1) * speed);
                break;
            case 7:
                anEnemy.transform.position = new Vector2(MCHammer.transform.position.x - 1, MCHammer.transform.position.y);
                anEnemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0) * speed);
                break;
        }

        if (i == 7)
        {
            i = 0;
        }
        else
        {
            i++;
        }
        
    }
}

