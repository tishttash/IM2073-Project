using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    public float timeRemaining;
    public bool timerIsRunning = false;
    public Text countdownText;
    public GameObject youLose;
    GameManager gameManager;

  private void Start()
  {
        // Starts the timer automatically
        timerIsRunning = true;
        gameManager = FindObjectOfType<GameManager>();
    }

  void Update()
  {
      if ( (timerIsRunning) && (gameManager.gameWin==false) )
      {
          if (timeRemaining > 0)
          {
              timeRemaining -= Time.deltaTime;
              DisplayTime(timeRemaining);
          }
          else
          {
                timeRemaining = 0;
                timerIsRunning = false;
                gameManager.gameWin = false;
                youLose.SetActive(true);
                gameManager.EndGame();
          }
      }
  }

  void DisplayTime(float timeToDisplay)
  {
      timeToDisplay += 1;

      float minutes = Mathf.FloorToInt(timeToDisplay / 60);
      float seconds = Mathf.FloorToInt(timeToDisplay % 60);

      countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
  }
}
