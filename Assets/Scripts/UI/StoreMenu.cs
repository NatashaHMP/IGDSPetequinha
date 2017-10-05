using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreMenu : MonoBehaviour {




    public GameObject YellowType
    {
        get { return yellowType; }
        set { yellowType = value; }
    }
    [SerializeField]
    private GameObject yellowType;

    public GameObject YellowSkin
    {
        get { return yellowSkin; }
        set { yellowSkin = value; }
    }
    [SerializeField]
    private GameObject yellowSkin;


    public Text TxtCoin
    {
        get { return txtCoin; }
        set { txtCoin = value; }
    }
    [SerializeField]
    private Text txtCoin;

    public Button Menu
    {
        get { return menu; }
        set { menu = value; }
    }
    [SerializeField]
    private Button menu;

    public Button StoreBtn
    {
        get { return storeBtn; }
        set { storeBtn = value; }
    }
    [SerializeField]
    private Button storeBtn;

    private Animator animator;


    //PRINCIPAL
    public Button PlayerType1
    {
        get { return playerType1; }
        set { playerType1 = value; }
    }
    [SerializeField]
    private Button playerType1;

    public Button PlayerType2
    {
        get { return playerType2; }
        set { playerType2 = value; }
    }
    [SerializeField]
    private Button playerType2;



    public Button PlayerPadrao
    {
        get { return playerPadrao; }
        set { playerPadrao = value; }
    }
    [SerializeField]
    private Button playerPadrao;

    public Button PlayerSkin1
    {
        get { return playerSkin1; }
        set { playerSkin1 = value; }
    }
    [SerializeField]
    private Button playerSkin1;

    public Button PlayerSkin2
    {
        get { return playerSkin2; }
        set { playerSkin2 = value; }
    }
    [SerializeField]
    private Button playerSkin2;

    public Button PlayerSkin3
    {
        get { return playerSkin3; }
        set { playerSkin3 = value; }
    }
    [SerializeField]
    private Button playerSkin3;




    //LOJA
    private int CorinthiansPrice;
    private int SantosPrice;
    private int PalmeirasPrice;

    private void Awake()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        CorinthiansPrice = 10;
        SantosPrice = 10;
        PalmeirasPrice = 10;


        txtCoin = GameObject.Find("Coin").GetComponent<Text>();
        animator = GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        animator.SetBool("StoreScreen", true);
        WriteCoin();
    }

    private void WriteCoin()
    {
        txtCoin.text = MainGameStatus.instance._coin.ToString();
    }


    public void StorePress()
    {
        animator.SetBool("StoreScreen", true);
        WriteCoin();
        VerifyYellowTarget();
    }

    public void Type1()
    {
        MainGameStatus.instance._playerType = 0;
        yellowType.transform.position = new Vector2(-2.05f, yellowType.transform.position.y);
    }
    public void Type2()
    {
        MainGameStatus.instance._playerType = 1;
        yellowType.transform.position = new Vector2(-0.72f, yellowType.transform.position.y);
    }








    public void Corinthians()
    {
        if (MainGameStatus.instance._CorinthiansLock == 0)
        {
            if (MainGameStatus.instance._coin >= CorinthiansPrice)
            {
                MainGameStatus.instance._coin = MainGameStatus.instance._coin - CorinthiansPrice;
                MainGameStatus.instance._CorinthiansLock = 1;
                MainGameStatus.instance._playerSkin = 0;
                yellowSkin.transform.position = new Vector2(-1.83f, yellowSkin.transform.position.y);
                PlayerPrefs.SetInt("CorinthiansKey", MainGameStatus.instance._CorinthiansLock);
                WriteCoin();
            }
        }
        else
        {
            MainGameStatus.instance._playerSkin = 0;
            yellowSkin.transform.position = new Vector2(-1.83f, yellowSkin.transform.position.y);
        }


        WriteCoin();
    }

    public void Santos()
    {
        if (MainGameStatus.instance._SantosLock == 0)
        {
            if (MainGameStatus.instance._coin >= SantosPrice)
            {
                MainGameStatus.instance._coin = MainGameStatus.instance._coin - SantosPrice;
                MainGameStatus.instance._SantosLock = 1;
                MainGameStatus.instance._playerSkin = 1;
                yellowSkin.transform.position = new Vector2(2f, yellowSkin.transform.position.y);
                PlayerPrefs.SetInt("SantosKey", MainGameStatus.instance._SantosLock);
                WriteCoin();
            }
        }
        else
        {
            MainGameStatus.instance._playerSkin = 1;
            yellowSkin.transform.position = new Vector2(2f, yellowSkin.transform.position.y);
        }

    }


    public void Palmeiras()
    {
        if (MainGameStatus.instance._PalmeirasLock == 0)
        {
            if (MainGameStatus.instance._coin >= PalmeirasPrice)
            {
                MainGameStatus.instance._coin = MainGameStatus.instance._coin - PalmeirasPrice;
                MainGameStatus.instance._PalmeirasLock = 1;
                MainGameStatus.instance._playerSkin = 2;
                yellowSkin.transform.position = new Vector2(0.16f, yellowSkin.transform.position.y);
                PlayerPrefs.SetInt("PalmeirasKey", MainGameStatus.instance._PalmeirasLock); 
                WriteCoin();
            }
        }
        else
        {
            MainGameStatus.instance._playerSkin = 2;
            yellowSkin.transform.position = new Vector2(0.16f, yellowSkin.transform.position.y);
        }

    }



    public void Padrao()
    {
        MainGameStatus.instance._playerSkin = 3;
        yellowSkin.transform.position = new Vector2(5f, yellowSkin.transform.position.y);
    }


    public void MenuPress()
    {
        PlayerPrefs.SetInt("PlayerType", MainGameStatus.instance._playerType);
        PlayerPrefs.SetInt("PlayerSkin", MainGameStatus.instance._playerSkin);
        animator.SetBool("StoreScreen", false);
    }

    private void VerifyYellowTarget()
    {
        if(MainGameStatus.instance._playerType == 1)
        {
            yellowType.transform.position = new Vector2(-0.72f, yellowType.transform.position.y);
        }



        if (MainGameStatus.instance._playerSkin == 0)
        {
            yellowSkin.transform.position = new Vector2(-1.83f, yellowSkin.transform.position.y);
        }

        if (MainGameStatus.instance._playerSkin == 1)
        {
            yellowSkin.transform.position = new Vector2(2f, yellowSkin.transform.position.y);
        }

        if (MainGameStatus.instance._playerSkin == 2)
        {
            yellowSkin.transform.position = new Vector2(0.16f, yellowSkin.transform.position.y);
        }

        if (MainGameStatus.instance._playerSkin == 3)
        {
            yellowSkin.transform.position = new Vector2(5f, yellowSkin.transform.position.y);
        }

    }

}
