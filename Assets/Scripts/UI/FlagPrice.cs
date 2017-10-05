using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPrice : MonoBehaviour {

    public GameObject CorinthiansFlag
    {
        get { return corinthiansFlag; }
        set { corinthiansFlag = value; }
    }
    [SerializeField]
    private GameObject corinthiansFlag;

    public GameObject SantosFlag
    {
        get { return santosFlag; }
        set { santosFlag = value; }
    }
    [SerializeField]
    private GameObject santosFlag;

    public GameObject PalmeirasFlag
    {
        get { return palmeirasFlag; }
        set { palmeirasFlag = value; }
    }
    [SerializeField]
    private GameObject palmeirasFlag;


    private void Update()
    {
        FlagsControl();
    }

    private void FlagsControl()
    {
        if(MainGameStatus.instance._CorinthiansLock == 1)
        {
            corinthiansFlag.SetActive(false);
        }
        if (MainGameStatus.instance._SantosLock == 1)
        {
            SantosFlag.SetActive(false);
        }
        if (MainGameStatus.instance._PalmeirasLock == 1)
        {
            palmeirasFlag.SetActive(false);
        }
    }


}
