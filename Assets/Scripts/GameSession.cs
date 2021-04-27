using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{
    //Config Parameters
    [Header("Points for Bricks")]
    [SerializeField] float pointsPerBlockDestroyed = 100;
    [SerializeField] float pointsPerBlockHit = 50;
    

    [Header("Game Speed & Autoplay")]
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] bool isAutoPlayEnabled = false;

    [Header("Difficulty Modifiers")]
    [SerializeField] float scoreModifierEasy = 0.75f;
    [SerializeField] float scoreModifierNormal = 1f;
    [SerializeField] float scoreModifierHard = 1.75f;
    [SerializeField] float speedModifierEasy = 0.75f;
    [SerializeField] float speedModifierNormal = 1f;
    [SerializeField] float speedModifierHard = 1.5f;

    //State Variables
    [SerializeField] int currentScore = 0;
    [SerializeField] int currentLevel = 0;

    int currentLives = 0;
    int explosiveBallEnabled;
    bool isEasy = false;
    bool isNormal = false;
    bool isHard = false;

    GameCanvas gameCanvas;

    private void Awake() //Singleton pattern to only have one game session
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() 
    {
        Application.targetFrameRate = 300;
        currentLives = PlayerPrefsController.GetTotalLives();
        explosiveBallEnabled = PlayerPrefsController.GetExplosiveBallEnabled();
        gameCanvas = FindObjectOfType<GameCanvas>();
        gameCanvas.DisplayScore(currentScore);
        gameCanvas.DisplayLevel(currentLevel);
        gameCanvas.DisplayLives(currentLives);
    }

    void Update()
    {
        Time.timeScale = gameSpeed; //Allows speed of game to be changed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<Ball>().StopBall();
            FindObjectOfType<LoseCollider>().EscapeBallReset();
        }
    }

    public void AddScoreDestroyed() //Adds and displays score for destroying a block
    {
        currentScore += Convert.ToInt32(pointsPerBlockDestroyed);
        gameCanvas.DisplayScore(currentScore);
    }

    public void AddScoreHit() //Adds and displays score for hitting a block
    {
        currentScore += Convert.ToInt32(pointsPerBlockHit);
        gameCanvas.DisplayScore(currentScore);
    }

    public void ResetGame() //Removes current game session
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled() //Returns if autoplay is enabled
    {
        return isAutoPlayEnabled;
    }

    public void EasyModifiers() //Score and speed for EASY mode
    {
        pointsPerBlockHit = pointsPerBlockHit * scoreModifierEasy;
        pointsPerBlockDestroyed = pointsPerBlockDestroyed * scoreModifierEasy;
        isEasy = true;
    }

    public bool ReturnEasy() { return isEasy; }

    public void NormalModifiers() //Score and speed for NORMAL mode
    {
        pointsPerBlockHit = pointsPerBlockHit * scoreModifierNormal;
        pointsPerBlockDestroyed = pointsPerBlockDestroyed * scoreModifierNormal;
        isNormal = true;
    }

    public bool ReturnNormal() { return isNormal; }

    public void HardModifiers() //Score and speed for HARD mode
    {
        pointsPerBlockHit = pointsPerBlockHit * scoreModifierHard;
        pointsPerBlockDestroyed = pointsPerBlockDestroyed * scoreModifierHard;
        isHard = true;
    }

    public bool ReturnHard() { return isHard; }

    public void LevelIncrease() //Increases level and displays to canvas
    {
        currentLevel++;
        gameCanvas.DisplayLevel(currentLevel);
    }

    public int ConvertScoreToCurrency() //Changes score to currency and returns it
    {
        int sessionCurrency = currentScore / 100;
        return sessionCurrency;
    }

    public int ReturnCurrentLevel() { return currentLevel; } //Returns current level

    public int ReturnCurrentScore() { return currentScore; } //Returns current score
    
    public int HandleLivesLost() //Reduces lives by 1 and returns current amount and displays it
    {
        currentLives = currentLives - 1;
        gameCanvas.DisplayLives(currentLives);
        return currentLives;
    }

    public void UpdateLives()
    {
        gameCanvas.DisplayLives(PlayerPrefsController.GetTotalLives());
    }

    public void SecondChanceLivesIncrease()
    {
        currentLives = currentLives + 1;
        gameCanvas.DisplayLives(currentLives);
    }

    public void UpdateCurrentLives()
    {
        currentLives = PlayerPrefsController.GetTotalLives();
    }
}
