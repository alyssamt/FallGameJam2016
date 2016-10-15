using UnityEngine;
using System.Collections;



public class MCMove : MonoBehaviour
{

    public float maxX = 8F;
    public float minX = -8F;
    public int moveSpeed = 5;

    public float tChange = 0;
    public float randomX = 0;

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
            // change to random direction at random intervals
            if (Time.time >= tChange)
            {
                randomX = Random.Range(0.0F, 1.0F);
                // set a random interval between 0.7 and 0.9
                tChange = Time.time + Random.Range(0.7F, 0.9F);
            }
            if (randomX <= 0.5F)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            else if (randomX > 0.5F)
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            }// if object reached any border, revert the appropriate direction
            if (transform.position.x >= maxX || transform.position.x <= minX)
            {
                randomX = 1 - randomX;
            }

            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp(pos.x, 0.0F, 1.0F);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }
}