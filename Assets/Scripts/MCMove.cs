using UnityEngine;
using System.Collections;


public class MCMove : MonoBehaviour
{
    //public bool active = false;
    float timeOffset = 0;
    int xdir, ydir, rand;
    public bool move;
    
    Vector2 destination;
    // Use this for initialization
    void Start()
    {
        RandomDirection();
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Debug.Log("MCMove Update");
        
        if(move)
        {
            destination = new Vector2(transform.position.x + (xdir * 0.01f), transform.position.y + (ydir * 0.01f));
            while (destination.x < min.x || destination.x > max.x || destination.y < min.y || destination.y > max.y)
            {
                Debug.Log("RandomDir Loop");
                RandomDirection();
                destination = new Vector2(transform.position.x + (xdir * 0.02f), transform.position.y + (ydir * 0.02f));
            }
            transform.position = destination;
        }
        
        


            //transform.position = new Vector2(Mathf.PingPong(Time.time + timeOffset, (2 * max.x)) - max.x, Mathf.PingPong(Time.time + timeOffset, (2 * max.y)) - max.y);
    }
    
    void RandomDirection()
    {
        rand = Random.Range(0, 2);
        if (rand < 1f) xdir = 1; else xdir = -1;
        rand = Random.Range(0, 2);
        if (rand < 1f) ydir = 1; else ydir = -1;
    }

    public void TimeReset()
    {
        timeOffset = -Time.time;
    }

    public void Reset()
    {
        transform.position = new Vector2(0, 2.5f);
    }
}