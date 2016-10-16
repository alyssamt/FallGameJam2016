using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public GameManager gm;
    public float speed = 3.0f;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    /*void Update()
    {
        if (!gm.doingSetup)
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move * speed * Time.deltaTime;
        }
        //Debug.Log("Player position: " + transform.position);
    }*/

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

	void LoadLevel()
	{
		gm.OnLevelWasLoaded();
	}

	void FinishGame()
	{
		gm.GameOver();
	}

    private IEnumerator SecondsDelay()
    {
        this.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(2);
        this.GetComponent<PlayerMovement>().enabled = true;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!gm.doingSetup)
        {
            GameObject collidedWith = coll.transform.gameObject;

            if (collidedWith.name == "MC Hammer")
            {
                StartCoroutine(SecondsDelay());
                Invoke("LoadLevel" ,1);
            }
            else if (collidedWith.tag == "Obstacle")
            {
                Debug.Log("You collided with " + collidedWith.name);
                StartCoroutine(SecondsDelay());
                Invoke("FinishGame", 1);
            }
        }
    }
}