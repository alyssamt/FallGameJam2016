using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public GameManager gm;
    public float speed = 7.0f;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

	void Update()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		if (!gm.doingSetup)
		{
			var move = new Vector3(0,0,0);
			move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
			var total = move * speed * Time.deltaTime;
			if (transform.position.x + total.x <= max.x && transform.position.y + total.y <= max.y && transform.position.x + total.x >= min.x && transform.position.y + total.y >= min.y) {
				transform.position += total;
			}

		}
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!gm.doingSetup)
        {
            GameObject collidedWith = coll.transform.gameObject;

            if (collidedWith.name == "MC Hammer")
            {
                gm.OnLevelWasLoaded();
            }
            else if (collidedWith.tag == "Obstacle")
            {
                Debug.Log("You collided with " + collidedWith.name);
                gm.GameOver();
            }
        }
    }
}