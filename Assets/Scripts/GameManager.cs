using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.UI;                   //Allows us to use UI.

public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 2f;                      //Time to wait before starting level, in seconds.
    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public bool doingSetup = true;

    private Text levelText;                                 //Text to display current level number.
    private GameObject levelImage;                          //Image to block out level as levels are being set up, background for levelText.
    private GameObject playAgainButton;
    private GameObject player;
    private int level = 1;                                  //Current level number, expressed in game as "Day 1".

    private string[] levelProgression = {"", "", "RocketSpawner", "MCMove"};
    private RocketSpawner RocketSpawner;
    private MCMove MCMove;

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

        RocketSpawner = GameObject.Find("RocketSpawner").GetComponent<RocketSpawner>();
        MCMove = GameObject.Find("MC Hammer").GetComponent<MCMove>();

        levelImage.SetActive(false);
        playAgainButton.SetActive(false);

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //This is called each time a scene is loaded.
    public void OnLevelWasLoaded()
    {
        //Add one to our level number.
        level++;
        //Call InitGame to initialize our level.
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        doingSetup = true;
        player.transform.position = new Vector3(0, -3, 0);
        InitObstacles();
        levelText.text = "Level " + level;
        levelImage.SetActive(true);
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
            RocketSpawner.BeginSpawning();
        } else if (currObstacle == "MCMove")
        {
            MCMove.active = true;
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
    }


    public void GameOver()
    {
        levelText.text = "YOU CAN'T TOUCH THIS";
        levelImage.SetActive(true);
        playAgainButton.SetActive(true);
        enabled = false;
    }

    public void PlayAgain()
    {
        level = 1;
        playAgainButton.SetActive(false);
        InitGame();
    }
}