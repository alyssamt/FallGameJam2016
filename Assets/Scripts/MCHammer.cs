﻿using UnityEngine;
using System.Collections;

public class MCHammer : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter2D (Collision2D coll)
    {
        Debug.Log("YOU TOUCHED MC HAMMER");
    }
}
