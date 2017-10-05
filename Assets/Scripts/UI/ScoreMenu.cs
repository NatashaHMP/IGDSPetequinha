using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreMenu : MonoBehaviour {

    public Text TxtFirst
    {
        get { return txtFirst; }
        set { txtFirst = value; }
    }
    [SerializeField]
    private Text txtFirst;

    public Text TxtSecond
    {
        get { return txtSecond; }
        set { txtSecond = value; }
    }
    [SerializeField]
    private Text txtSecond;

    public Text TxtThird
    {
        get { return txtThird; }
        set { txtThird = value; }
    }
    [SerializeField]
    private Text txtThird;

    public Button Menu
    {
        get { return menu; }
        set { menu = value; }
    }
    [SerializeField]
    private Button menu;

    public Button ScoreBtn
    {
        get { return scoreBtn; }
        set { scoreBtn = value; }
    }
    [SerializeField]
    private Button scoreBtn;

    private Animator animator;

    private void Awake()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        txtFirst = GameObject.Find("First").GetComponent<Text>();
        txtSecond = GameObject.Find("Second").GetComponent<Text>();
        txtThird = GameObject.Find("Third").GetComponent<Text>();
        animator = GetComponent<Animator>();
        gameObject.SetActive(false);
    }


    public void MenuPress()
    {
        animator.SetBool("ScoreScreen", false);

    }

    public void ScorePress()
    {
        animator.SetBool("ScoreScreen", true);
        WriteRank();
    }

    private void OnEnable()
    {
        animator.SetBool("ScoreScreen", true);
        WriteRank();
    }


    private void WriteRank()
    {
        txtFirst.text = MainGameStatus.instance._firstScore.ToString();
        txtSecond.text = MainGameStatus.instance._secondScore.ToString();
        txtThird.text = MainGameStatus.instance._thirtScore.ToString();
    }

}
