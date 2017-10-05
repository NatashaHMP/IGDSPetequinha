using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Button Restart
    {
        get { return restart; }
        set { restart = value; }
    }
    [SerializeField]
    private Button restart;

    public Button Menu
    {
        get { return menu; }
        set { menu = value; }
    }
    [SerializeField]
    private Button menu;


    public Text TxtScore
    {
        get { return txtScore; }
        set { txtScore = value; }
    }
    [SerializeField]
    private Text txtScore;

    private void Start()
    {


        WriteScore();
        LoadResources();
    }


    private void WriteScore() {
        txtScore = GameObject.Find("Score").GetComponent<Text>();
        txtScore.text = MainGameStatus.instance._score.ToString();
    }



    private void LoadResources()
    {
        MainGameStatus.instance._currentDifficulty = 0;
    }


    public void MenuPress()
    {
        MainGameStatus.instance._score = 0;
        SceneManager.LoadScene("Menu");

    }


    public void RestartPress()
    {
        MainGameStatus.instance._score = 0;
        MainGameStatus.instance._gameisRun = true;
        SceneManager.LoadScene("Game");

    }

}
