﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.UI;                   //Allows us to use UI.

public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 2f;                      //Time to wait before starting level, in seconds.
    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public bool doingSetup = true;
    public int level = 1;

    private Text levelText;                                 //Text to display current level number.
    private GameObject levelImage;                          //Image to block out level as levels are being set up, background for levelText.
    private GameObject playAgainButton;
    private GameObject player;

    private string[] levelProgression = {"", "", "MCMove", "HammerSpawner", "RocketSpawner"};
    private HammerSpawn HammerSpawner;
    private RocketSpawner RocketSpawner;
    private MCMove MCMove;

    //SCORE - score calculation parameter
    public int winScore = 500;
    public float scoreRate = 1.5f;

    GameObject scoreUITextGO; //SCORE - reference to the text UI game object
    
    
    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        player = GameObject.Find("Player");
        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        playAgainButton = GameObject.Find("PlayAgainButton");

        HammerSpawner = GameObject.Find("HammerSpawner").GetComponent<HammerSpawn>();
        RocketSpawner = GameObject.Find("RocketSpawner").GetComponent<RocketSpawner>();
        MCMove = GameObject.Find("MC Hammer").GetComponent<MCMove>();

        levelImage.SetActive(false);
        playAgainButton.SetActive(false);

        //SCORE - get the score text UI
        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //This is called each time a scene is loaded.
    public void OnLevelWasLoaded()
    {
        scoreUITextGO.GetComponent<GameScore>().Score += (int)(winScore * Mathf.Pow(scoreRate, level));
        level++;
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        doingSetup = true;
        levelText.text = "Level " + level;
        levelImage.SetActive(true);
        DestroyAllObstacles();
        player.transform.position = new Vector3(0, -3, 0);
        InitObstacles();
        Invoke("HideLevelImage", levelStartDelay);

    }


    void InitObstacles()
    {
        if (level >= levelProgression.Length)
        {
            return;
        }

        string currObstacle = levelProgression[level];

        if (currObstacle == "RocketSpawner")
        {
            RocketSpawner.active = true;
        } else if (currObstacle == "MCMove")
        {
            MCMove.active = true;
        } else if (currObstacle == "HammerSpawner")
        {
            HammerSpawner.active = true;
        }

        RocketSpawner.IncreaseSpawnRate();
    }


    //Hides black image used between levels
    void HideLevelImage()
    {
        //Disable the levelImage gameObject.
        levelImage.SetActive(false);

        //Set doingSetup to false allowing player to move again.
        doingSetup = false;
    }

    //Update is called every frame.
    void Update()
    {
        if (doingSetup)
            return;
        //SCORE - decrease score
        if (scoreUITextGO.GetComponent<GameScore>().Score > 0)
            scoreUITextGO.GetComponent<GameScore>().Score -= 1;
    }


    public void GameOver()
    {
        DisableAll();
        levelText.text = "YOU CAN'T TOUCH THIS";
        levelImage.SetActive(true);
        playAgainButton.SetActive(true);    
        enabled = false;
    }

    public void PlayAgain()
    {
        level = 1;

        //SCORE - reset score
        scoreUITextGO.GetComponent<GameScore>().Score = 0;

        playAgainButton.SetActive(false);
        InitGame();
    }


    public void DisableAll()
    {
        doingSetup = true;
        HammerSpawner.active = false;
        RocketSpawner.active = false;
        DestroyAllObstacles();
    }


    public void DestroyAllObstacles()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Obstacle");

        for (var i = 0; i < gameObjects.Length; i++)
            Destroy(gameObjects[i]);
    }
}