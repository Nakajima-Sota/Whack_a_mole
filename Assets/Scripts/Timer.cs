using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 


public class Timer : MonoBehaviour
{
    public Text timerText;
    private float timeRemaining = 60.0f;
    private bool timerRunning = true;

    public float TimeRemaining => timeRemaining;

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timerText.text = "écÇË " + Mathf.Ceil(timeRemaining) + " ïb";
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;
                timerText.text = "èIóπ";
            }
        }
    }
}
