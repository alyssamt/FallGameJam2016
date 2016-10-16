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

    void Update()
    {
        if (!gm.doingSetup)
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move * speed * Time.deltaTime;
        }
        //Debug.Log("Player position: " + transform.position);
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