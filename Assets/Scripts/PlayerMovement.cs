using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public GameManager gm;
    public float speed = 3.0f;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Reset();
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


    public void Reset()
    {
        transform.position = new Vector2(0, -3);
    }


	void LoadLevel()
	{
		gm.OnLevelWasLoaded();
	}

	void FinishGame()
	{
		gm.GameOver();
	}

    IEnumerator SecondsDelay()
    {
        yield return new WaitForSeconds(1);
        GetComponent<PlayerMovement>().enabled = true;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!gm.doingSetup)
        {
            GameObject collidedWith = coll.transform.gameObject;

            if (collidedWith.name == "MC Hammer")
            {
                gm.RemoveTime();
                GetComponent<PlayerMovement>().enabled = false;
                Invoke("LoadLevel", 1f);
                StartCoroutine(SecondsDelay());
            }
            else if (collidedWith.tag == "Obstacle")
            {
                Debug.Log("You collided with " + collidedWith.name);
                gm.RemoveTime();
                GetComponent<PlayerMovement>().enabled = false;
                Invoke("FinishGame", 1);
                StartCoroutine(SecondsDelay());
            }
        }
    }
}