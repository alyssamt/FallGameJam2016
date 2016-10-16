using UnityEngine;
using System.Collections;



public class MCMove : MonoBehaviour
{


    public int moveSpeed = 5;

    private float tChange = 0;
    private float randomX = 0;
    private float distance = 0;

    public bool active = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            transform.position = new Vector2(Mathf.PingPong(Time.time * 3, (2 * max.x)) - max.x, Mathf.PingPong(Time.time * 3, (2 * max.y)) - max.y);
        }
    }
}