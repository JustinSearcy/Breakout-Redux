using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupsAndLives : MonoBehaviour
{
    [SerializeField] int lives = 1;
    [SerializeField] float paddleSizeMultiplier = 1f;
    [SerializeField] float paddleIncrease = 0.25f;
    [SerializeField] float secondChanceRate = 0f;
    [SerializeField] float secondChanceRateChange = .1f;
    [SerializeField] int explosiveBallEnabled = 0; //0 is not enabled, 1 is enabled

    private void Awake() //Saves powerup values to initial
    {
        PlayerPrefsController.InitializeTotalLives();
        PlayerPrefsController.InitializePaddleSize();
        PlayerPrefsController.InitializeSecondChanceRate();
    }


    //-----------------------------------GET INITIAL VALUES-----------------------------
    public int GetInitialLives() { return lives; }

    public float GetInitialPaddleSize() { return paddleSizeMultiplier; }

    public float GetInitialSecondChanceRate() { return secondChanceRate; }

    public int GetInitialExplosiveBallEnabled() { return explosiveBallEnabled; }


    //-----------------------------------INCREASE POWERUPS------------------------------

    public void IncreaseLives() //Add 1 to total lives and save value
    {
        PlayerPrefsController.SetTotalLives(PlayerPrefsController.GetTotalLives() + 1);
        FindObjectOfType<GameSession>().UpdateLives();
    }

    public void IncreasePaddleSize() //Increases paddle size and saves value
    {
        PlayerPrefsController.SetPaddleSize(PlayerPrefsController.GetPaddleSize() + paddleIncrease);
    }    

    public void IncreaseSecondChanceRate() //Increases rate of second chance and saves value
    {
        PlayerPrefsController.SetSecondChanceRate(PlayerPrefsController.GetSecondChanceRate() + secondChanceRateChange);
    }

    public void EnableExplosiveBall() //Set explosive ball to enabled
    {
        PlayerPrefsController.SetExplosiveBallEnabled(1);
        FindObjectOfType<GameCanvas>().EnableExplosiveBall();
    }
}
