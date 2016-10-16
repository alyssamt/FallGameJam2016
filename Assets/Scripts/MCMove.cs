using UnityEngine;
using System.Collections;


public class MCMove : MonoBehaviour
{
    //public bool active = false;
    float timeOffset = 0;
    // Use this for initialization
    void Start()
    {
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.enabled)
        {
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            transform.position = new Vector2(Mathf.PingPong(Time.time + timeOffset, (2 * max.x)) - max.x, Mathf.PingPong(Time.time + timeOffset, (2 * max.y)) - max.y);
        }
    }

    public void TimeReset()
    {
        timeOffset = -Time.time;
    }
}