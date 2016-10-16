using UnityEngine;
using System.Collections;

public class BGDancer : MonoBehaviour
{
    public Transform center;
    public float degreesPerSecond = -65.0f;
    public GameManager gm;

    private Vector3 v;

    // Use this for initialization
    void Start()
    {
        v = transform.position - center.position;
    }

    // Update is called once per frame
    void Update()
    {
        v = Quaternion.AngleAxis(degreesPerSecond * Time.deltaTime, Vector3.forward) * v;
        transform.position = center.position + v;
    }
    /*
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.name == "Player")
        {
            gm.GameOver();
        }
    }
    */
}
