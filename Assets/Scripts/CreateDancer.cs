﻿using UnityEngine;
using System.Collections;

public class CreateDancer : MonoBehaviour {
    
    public GameObject dancer;
    public GameObject MCHammer;
    public int spawnMax = 1;
    public GameManager gm;

    void Start()
    {
        MCHammer = GameObject.Find("MC Hammer");
    }

    
    public void Spawn()
    {
        float degreesPerSpawn = 360f / ((float)spawnMax);
        for (int i = 0; i < spawnMax; i++)
        {
            Vector3 directionOffset = Quaternion.AngleAxis(degreesPerSpawn * i, Vector3.forward) * Vector2.up * 3;
            GameObject newBG = (GameObject)Instantiate(dancer, MCHammer.transform.position + directionOffset, Quaternion.identity);
            newBG.GetComponent<BGDancer>().center = this.MCHammer.transform;
            newBG.GetComponent<BGDancer>().gm = this.gm;
        }
    }
}
