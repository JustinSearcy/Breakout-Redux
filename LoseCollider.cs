using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] float timeBeforeGameOver = 3f;
    [SerializeField] float timeBeforeReset = 2f;
    [SerializeField] float timeBeforeDissolve = 1f;

    Block[] blocks;
    Shake shake;
    Timer timer;
    Ball ball;
    GameSession gameSession;
    Paddle paddle;
    GameCanvas gameCanvas;

    float secondChanceProc;
    bool isColliding = false;

    private void Start()
    {
        blocks = FindObjectsOfType<Block>();
        shake = FindObjectOfType<Shake>();
        timer = FindObjectOfType<Timer>();
        ball = FindObjectOfType<Ball>();
        gameSession = FindObjectOfType<GameSession>();
        paddle = FindObjectOfType<Paddle>();
        gameCanvas = FindObjectOfType<GameCanvas>();

        secondChanceProc = UnityEngine.Random.Range(0f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D other) //When ball hits offscreen collider, end the game
    {
        if (isColliding) { return; } //Prevent multiple calls
        else
        {
            isColliding = true;
            timer.StopTimer();
            other.gameObject.GetComponent<TrailRenderer>().enabled = false;
            shake.CamShake();
            var currentLives = gameSession.HandleLivesLost();
            if (currentLives <= 0)
            {
                if (PlayerPrefsController.GetSecondChanceRate() > secondChanceProc)
                {
                    StartCoroutine(SecondChanceResetPaddlesAndBall());
                }
                else
                {
                    timer.SaveTimerValue();
                    StartCoroutine(StartBlockDissolve());
                    StartCoroutine(LoadGameOver()); ;
                }
            }
            else
            {
                StartCoroutine(ResetPaddlesAndBall());
            }
        }
    }

    IEnumerator StartBlockDissolve()
    {
        yield return new WaitForSeconds(timeBeforeDissolve);
        for(int blockCount = 0; blockCount < blocks.Length; blockCount++)
        {
            blocks[blockCount].BlockDissolve();  
        }
    }

    IEnumerator LoadGameOver() //Waits and loads game over, sets cursor to visible
    {
        yield return new WaitForSeconds(timeBeforeGameOver);
        SceneManager.LoadScene("Game Over");
        if(FindObjectOfType<ExplosiveBallSlider>() != null)
        {
            FindObjectOfType<ExplosiveBallSlider>().Reset();
        }
    }

    IEnumerator ResetPaddlesAndBall()
    {
        yield return new WaitForSeconds(timeBeforeReset);
        ball.ResetBall();
        paddle.ResetPaddle();
        isColliding = false;
    }

    IEnumerator SecondChanceResetPaddlesAndBall()
    {
        gameCanvas.SecondChanceAnimation();
        yield return new WaitForSeconds(timeBeforeReset);
        secondChanceProc = UnityEngine.Random.Range(0f, 1f);
        gameSession.SecondChanceLivesIncrease();
        ball.ResetBall();
        paddle.ResetPaddle();
        isColliding = false;
    }

    public void EscapeBallReset()
    {
        timer.StopTimer();
        ball.GetComponent<TrailRenderer>().enabled = false;
        var currentLives = gameSession.HandleLivesLost();
        if (currentLives <= 0)
        {
            if (PlayerPrefsController.GetSecondChanceRate() > secondChanceProc)
            {
                StartCoroutine(SecondChanceResetPaddlesAndBall());
            }
            else
            {
                timer.SaveTimerValue();
                StartCoroutine(StartBlockDissolve());
                StartCoroutine(LoadGameOver()); ;
            }
        }
        else
        {
            StartCoroutine(ResetPaddlesAndBall());
        }
    }
}
