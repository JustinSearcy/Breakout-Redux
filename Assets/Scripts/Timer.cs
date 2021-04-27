using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    float startTime, stopTime, timerTime;
    bool isRunning = false;
    string savedMinutes, savedSeconds;

    public void StartTimer()
    {
        if(!isRunning)
        {
            isRunning = true;
            startTime = Time.time;
        }
    }

    public void StopTimer()
    {
        if (isRunning)
        {
            isRunning = false;
            stopTime = timerTime;
        }
    }

    public void TimerReset()
    {
        stopTime = 0;
        isRunning = false;
        timerText.text = "00:000";
    }

    private void Update()
    {
        timerTime = stopTime + (Time.time - startTime);
        string minutes = ((int) timerTime / 60).ToString();
        string seconds = (timerTime % 60).ToString("f2");
       if(isRunning)
        {
            timerText.text = minutes + ":" + seconds;
        } 
    }

    public void SaveTimerValue()
    {
       savedMinutes = ((int)timerTime / 60).ToString();
       savedSeconds = (timerTime % 60).ToString("f2");
    }

    public string ReturnTime()
    {
        return savedMinutes + ":" + savedSeconds;
    }
}
