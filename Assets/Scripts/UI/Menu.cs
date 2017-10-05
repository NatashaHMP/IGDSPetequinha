using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Button Play
    {
        get { return play; }
        set { play = value; }
    }
    [SerializeField]
    private Button play;


    public Button Score
    {
        get { return score; }
        set { score = value; }
    }
    [SerializeField]
    private Button score;

    [SerializeField]
    public GameObject ScoreScreen;


    public Button Store
    {
        get { return store; }
        set { store = value; }
    }
    [SerializeField]
    private Button store;

    [SerializeField]
    public GameObject StoreScreen;


    public void PlayPress()
    {
        MainGameStatus.instance._gameisRun = true;
        SceneManager.LoadScene("Game");
    }


    public void ScorePress()
    {
        ScoreScreen.SetActive(true);
    }


    public void StorePress()
    {
        StoreScreen.SetActive(true);
    }
}
