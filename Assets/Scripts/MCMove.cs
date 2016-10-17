using UnityEngine;
using System.Collections;


public class MCMove : MonoBehaviour
{
    float timeOffset = 0;
    int xdir, ydir, rand;
    public bool move;
    public float speed;

    private Vector2 min;
    private Vector2 max;
    
    Vector2 destination;


    void Start()
    {
        RandomDirection();
        this.enabled = false;
        speed = 0.01f;
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }


    void Update()
    {

        if (move)
        {
            destination = new Vector2(transform.position.x + (xdir * speed), transform.position.y + (ydir * speed));
            while (destination.x < min.x || destination.x > max.x || destination.y < min.y || destination.y > max.y)
            {
                RandomDirection();
                destination = new Vector2(transform.position.x + (xdir * speed * 2), transform.position.y + (ydir * speed * 2));
            }
            transform.position = destination;
        }
    }
    

    public void RandomDirection()
    {
        rand = Random.Range(0, 2);
        if (rand < 1f) xdir = 1; else xdir = -1;
        rand = Random.Range(0, 2);
        if (rand < 1f) ydir = 1; else ydir = -1;
    }


    public void Reset()
    {
        transform.position = new Vector2(Random.Range(min.x, max.x), 2.5f);
    }


    public void SpeedUp()
    {
        if (speed <= 0.05f)
        {
            speed += 0.0025f;
        }
    }
}