using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDifficulty : MonoBehaviour {

    //CONTROLE MOBILE
    public GameObject ButtonDir
    {
        get { return ButtonDir; }
        set { ButtonDir = value; }
    }
    [SerializeField]
    private GameObject buttonDir;

    public GameObject ButtonEsq
    {
        get { return ButtonEsq; }
        set { ButtonEsq = value; }
    }
    [SerializeField]
    private GameObject buttonEsq;


    private const float MAX_DIFFICULTY = 1.3f;
    private float currentDifficulty = 1f;
    [SerializeField]
    private float gameTimer;
    private float timeToChange;


    private void Start()
    {
        gameTimer = 30;
        timeToChange = gameTimer;
        Time.timeScale = 0.0f;
    }


    private void Update () {
        StartEndGame();

        if (Time.timeScale != 0)
        {
            Timer();
            if (gameTimer <= 0)
            {
                SetDifficulty();
                gameTimer = timeToChange;
                timeToChange = timeToChange + 30;
            }
        }
    }

    private void Timer()
    {
        gameTimer-= Time.deltaTime;   
    }

    private void SetDifficulty()
    {
        if (currentDifficulty <= MAX_DIFFICULTY)
        {
            Time.timeScale = currentDifficulty;
            

            currentDifficulty = currentDifficulty + 0.1f;
        }
    }


    private void StartEndGame()
    {
        if (MainGameStatus.instance._gameisRun == false)
        {
              SceneManager.LoadScene("GameOver");
        }


        if (Input.GetKey("d") || Input.GetKey("a") && Time.timeScale == 0)
        {
            Time.timeScale = currentDifficulty;
        }

    }

    public void PlayPres()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = currentDifficulty;
        }
    }
}

