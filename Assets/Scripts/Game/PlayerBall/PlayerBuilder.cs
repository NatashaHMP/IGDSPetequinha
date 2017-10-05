using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuilder : MonoBehaviour {

    public GameObject Type0Corinthians
    {
        get { return type0Corinthians; }
        set { type0Corinthians = value; }
    }
    [SerializeField]
    private GameObject type0Corinthians;

    public GameObject Type0Santos
    {
        get { return type0Santos; }
        set { type0Santos = value; }
    }
    [SerializeField]
    private GameObject type0Santos;

    public GameObject Type0Palmeiras
    {
        get { return type0Palmeiras; }
        set { type0Palmeiras = value; }
    }
    [SerializeField]
    private GameObject type0Palmeiras;

    public GameObject Type0Padrao
    {
        get { return type0Padrao; }
        set { type0Padrao = value; }
    }
    [SerializeField]
    private GameObject type0Padrao;


    public GameObject Type1Corinthians
    {
        get { return type1Corinthians; }
        set { type1Corinthians = value; }
    }
    [SerializeField]
    private GameObject type1Corinthians;

    public GameObject Type1Santos
    {
        get { return type1Santos; }
        set { type1Santos = value; }
    }
    [SerializeField]
    private GameObject type1Santos;

    public GameObject Type1Palmeiras
    {
        get { return type1Palmeiras; }
        set { type1Palmeiras = value; }
    }
    [SerializeField]
    private GameObject type1Palmeiras;

    public GameObject Type1Padrao
    {
        get { return type1Padrao; }
        set { type1Padrao = value; }
    }
    [SerializeField]
    private GameObject type1Padrao;

    private void Awake()
    {
        //BuildPlayerType();
        DisableOthersObj();
    }

    private void BuildPlayerType()
    {
        //Instantiate(VerifyPlayerType(), new Vector3(-0.05f, -2.826f, 0.06f), Quaternion.identity);
    }

    private GameObject VerifyPlayerType()
    {
        if (MainGameStatus.instance._playerType == 0)
        {
            if (MainGameStatus.instance._playerSkin == 0)
            {
                return type0Corinthians;
            }
            else if (MainGameStatus.instance._playerSkin == 1)
            {
                return type0Santos;
            }
            else if (MainGameStatus.instance._playerSkin == 2) 
            {
                return type0Palmeiras;
            } else
            {
                return Type0Padrao;
            }

        }
        else
        {
            if (MainGameStatus.instance._playerSkin == 0)
            {
                return type1Corinthians;
            }
            else if (MainGameStatus.instance._playerSkin == 1)
            {
                return type1Santos;
            }
            else if (MainGameStatus.instance._playerSkin == 2)
            {
                return type1Palmeiras;
            } else
            {
                return type1Padrao;
            }
        }
    }

    private void DisableOthersObj()
    {
        if(VerifyPlayerType() != type0Corinthians)
        {
            type0Corinthians.SetActive(false);
        }
        if (VerifyPlayerType() != type0Palmeiras)
        {
            type0Palmeiras.SetActive(false);
        }
        if (VerifyPlayerType() != type0Santos)
        {
            type0Santos.SetActive(false);
        }
        if (VerifyPlayerType() != type1Corinthians)
        {
            type1Corinthians.SetActive(false);
        }
        if (VerifyPlayerType() != type1Santos)
        {
            type1Santos.SetActive(false);
        }
        if (VerifyPlayerType() != type1Palmeiras)
        {
            type1Palmeiras.SetActive(false);
        }
        if (VerifyPlayerType() != type1Padrao)
        {
            type1Padrao.SetActive(false);
        }
        if (VerifyPlayerType() != Type0Padrao)
        {
            Type0Padrao.SetActive(false);
        }
    }
}
