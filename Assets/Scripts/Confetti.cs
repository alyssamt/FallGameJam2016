using UnityEngine;
using System.Collections;

public class Confetti : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Vector3 direction = new Vector3(1.0f, Random.Range(3.0f, 6.0f), 0);
        this.GetComponent<Rigidbody2D>().AddForce(direction * 100f);
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }
}
