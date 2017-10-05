using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStatus : MonoBehaviour {
 
    public int _score;
    public bool _gameisRun;
    public float _currentDifficulty;

    public int _coin;
    public int _firstScore;
    public int _secondScore;
    public int _thirtScore;

    public int _playerSkin;
    public int _playerType;


    //SANTOS = 0
    // CORINTHIANS = 1
    // PALMEIRAS = 2
    //NEUTRO = 3

    public int _SantosLock;
    public int _CorinthiansLock;
    public int _PalmeirasLock;


    public static MainGameStatus instance;

    private void Awake()
    {
        _gameisRun = false;
        instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        LoadResources();
    }


    private void LoadResources()
    {
        _score = 0;

        // RANK
        if (PlayerPrefs.HasKey("PlayerFirst"))
        {
            _firstScore = PlayerPrefs.GetInt("PlayerFirst");
        } else {
            PlayerPrefs.SetInt("PlayerFirst", _firstScore);
        }

        if (PlayerPrefs.HasKey("PlayerSecond"))
        {
            _secondScore = PlayerPrefs.GetInt("PlayerSecond");
        } else {
            PlayerPrefs.SetInt("PlayerSecond", _secondScore);
        }

        if (PlayerPrefs.HasKey("PlayerThird"))
        {
            _thirtScore = PlayerPrefs.GetInt("PlayerThird");
        } else {
            PlayerPrefs.SetInt("PlayerThird", _thirtScore);
        }

        if (PlayerPrefs.HasKey("Coin"))
        {
            _coin = PlayerPrefs.GetInt("Coin");
        }
        else
        {
            PlayerPrefs.SetInt("Coin", _coin);
        }


        //PLAYER TYPE
        if (PlayerPrefs.HasKey("PlayerType"))
        {
            _playerType = PlayerPrefs.GetInt("PlayerType");
        }
        else
        {
        
            PlayerPrefs.SetInt("PlayerType", _playerType);
        }

        //PLAYER SKIN
        if (PlayerPrefs.HasKey("PlayerSkin"))
        {
            _playerSkin = PlayerPrefs.GetInt("PlayerSkin");
        }
        else
        {
            _playerSkin = 3;
            PlayerPrefs.SetInt("PlayerSkin", _playerSkin);
        }



        if (PlayerPrefs.HasKey("SantosKey"))
        {
            _SantosLock = PlayerPrefs.GetInt("SantosKey");
        }
        else
        {
            PlayerPrefs.SetInt("SantosKey", _SantosLock);
        }

        if (PlayerPrefs.HasKey("CorinthiansKey"))
        {
            _CorinthiansLock = PlayerPrefs.GetInt("CorinthiansKey");
        }
        else
        {
            PlayerPrefs.SetInt("CorinthiansKey", _CorinthiansLock);
        }

        if (PlayerPrefs.HasKey("PalmeirasKey"))
        {
            _PalmeirasLock = PlayerPrefs.GetInt("PalmeirasKey");
        }
        else
        {
            PlayerPrefs.SetInt("PalmeirasKey", _PalmeirasLock);
        }

    }

    private void Update()
    {

        if (_gameisRun == false && _score !=0)
        {
            ChangeRanking();
        }

    }


    private void ChangeRanking()
    {
        if (_score > _firstScore)
        {
            _thirtScore = _secondScore;
            _secondScore = _firstScore;
            _firstScore = _score;

        }
        else if (_score < _firstScore && _score > _secondScore)
        {
            _thirtScore = _secondScore;
            _secondScore = _score;
        }
        else if (_score < _secondScore && _score > _thirtScore)
        {
            _thirtScore = _score;
        }

        PlayerPrefs.SetInt("PlayerFirst", _firstScore);
        PlayerPrefs.SetInt("PlayerSecond", _secondScore);
        PlayerPrefs.SetInt("PlayerThird", _thirtScore);

        PlayerPrefs.SetInt("Coin", _coin);
    }
}
