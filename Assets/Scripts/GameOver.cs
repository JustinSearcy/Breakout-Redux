using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelReachedText;
    [SerializeField] TextMeshProUGUI scoreEarnedText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] Canvas gameOver;

    GameSession gameSession;
    Currency currency;

    
    void Start() //Display currency/score/level and applies session currency to the total
    {
        Cursor.visible = true;
        gameOver.worldCamera = Camera.main;
        gameSession = FindObjectOfType<GameSession>();
        currency = FindObjectOfType<Currency>();
        int sessionCurrency = gameSession.ConvertScoreToCurrency();
        levelReachedText.text = "Level Reached: " + gameSession.ReturnCurrentLevel();
        scoreEarnedText.text = "Score Earned: " + gameSession.ReturnCurrentScore() + " = $" + sessionCurrency;
        timeText.text = "Time Taken : " + FindObjectOfType<Timer>().ReturnTime();
        currency.FindSessionCurrency(sessionCurrency); 
    }
}
