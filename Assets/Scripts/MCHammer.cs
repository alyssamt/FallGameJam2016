using UnityEngine;
using System.Collections;

public class MCHammer : MonoBehaviour {

    public GameManager gm;

    //SCORE - score calculation parameter
    public int winScore = 500;
    public float scoreRate = 1.5f;
    public float level;

    GameObject scoreUITextGO; //SCORE - reference to the text UI game object

    // Use this for initialization
    void Start () {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        //SCORE - get the score text UI
        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter2D (Collision2D coll)
    {
        Debug.Log("YOU TOUCHED MC HAMMER");

        //add calculated points to the score
        scoreUITextGO.GetComponent<GameScore>().Score += (int) (winScore * Mathf.Pow(scoreRate, gm.level));
        Debug.Log(winScore);
        Debug.Log(scoreRate);
        Debug.Log(gm.level);
        Debug.Log(Mathf.Pow(scoreRate, gm.level));
        Debug.Log((int)(winScore * Mathf.Pow(scoreRate, gm.level)));
        gm.OnLevelWasLoaded();
    }
}
