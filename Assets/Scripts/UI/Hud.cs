using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hud : MonoBehaviour {

    public Text TxtScore
    {
        get { return txtScore; }
        set { txtScore = value; }
    }
    [SerializeField]
    private Text txtScore;

    public Text TxtCoin
    {
        get { return txtCoin; }
        set { txtCoin = value; }
    }
    [SerializeField]
    private Text txtCoin;


   


    private void Start()
    {
        LoadResources();
    }

    private void LoadResources()
    {
       
        txtScore = GameObject.Find("Score").GetComponent<Text>();
        txtCoin = GameObject.Find("Coin").GetComponent<Text>();
       
    }


    private void Update()
    {
        WriteScore();
        WriteCoin();

    }

   

  


    private void WriteScore()
    {
        txtScore.text = MainGameStatus.instance._score.ToString();
    }

    private void WriteCoin()
    {
        txtCoin.text = MainGameStatus.instance._coin.ToString();
    }

}
