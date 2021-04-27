using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreEarnedText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] Canvas winScreen;

    GameSession gameSession;
    Currency currency;


    void Start() //Display currency/score/level and applies session currency to the total
    {
        Cursor.visible = true;
        winScreen.worldCamera = Camera.main;
        gameSession = FindObjectOfType<GameSession>();
        currency = FindObjectOfType<Currency>();
        int sessionCurrency = gameSession.ConvertScoreToCurrency();
        scoreEarnedText.text = "Score Earned: " + gameSession.ReturnCurrentScore() + " = $" + sessionCurrency;
        timeText.text = "Time Taken : " + FindObjectOfType<Timer>().ReturnTime();
        currency.FindSessionCurrency(sessionCurrency);
    }
}
