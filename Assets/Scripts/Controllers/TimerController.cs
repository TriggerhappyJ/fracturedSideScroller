using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text timeText;

    private TimeSpan timePlaying;
    private bool timerRunning;

    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timeText.text = "00:00.00";
        timerRunning = false;
    }

    public void StartTimer()
    {
        timerRunning = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerRunning)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            timeText.text = timePlayingStr;

            yield return null;
        }
    }
}
