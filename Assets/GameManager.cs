using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CharacterController playercontroller;
    //public bool gameOver;
    public bool gameWin = false;
    public AudioSource audioSource;
    public int mushroomsPicked = 0; //total no. of mushrooms picked up
    public Countdown countdown;

    void Start()
    {
        //gameOver = false;
        audioSource = GetComponent<AudioSource>();
        AudioListener.volume = 1.0f;
        //audioSource.Play();
        //DontDestroyOnLoad(this.gameObject);
    }

    public void EndGame()
    {
        //gameOver = true;
        if (gameWin)
        {
            Debug.Log("GAME OVER. YOU WON! :)");
            playercontroller.enabled = false;
            SceneManager.LoadScene("WinMenu");
        }
        else //gameWin == false
        {
            Debug.Log("GAME OVER. YOU LOST! :(");
            //playercontroller.enabled = false;
        }
    }

    public void mushroomCountUpdate()
    {
        if(mushroomsPicked < 17)
        {
            mushroomsPicked++;
            Debug.Log("Mushrooms picked up: " + mushroomsPicked);
        }
        else
        {
            if(countdown.timeRemaining > 0)
            {
                gameWin = true;
                EndGame();
            }   
        }
    }
}
