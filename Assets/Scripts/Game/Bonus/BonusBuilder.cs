using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBuilder : MonoBehaviour {

    // DIFICULDADE
    private float currentDifficulty = 10f;
    private float timerSpawn;

    //OBSTACULOS
    public GameObject Bonus
    {
        get { return bonus; }
        set { bonus = value; }
    }
    [SerializeField]
    private GameObject bonus;


    private const int qntdBonus= 1;
    private List<GameObject> obstaclesList;
   

    private void Start()
    {
        LoadResources();
    }


    private void LoadResources()
    {

        timerSpawn = currentDifficulty;

        obstaclesList = new List<GameObject>();
        for (int i = 0; i < qntdBonus; i++)
        {
            GameObject obj = (GameObject)Instantiate(bonus);

            obj.SetActive(false);
            obstaclesList.Add(obj);
        }
    }


    private void Update()
    {

        Timer();
        if (timerSpawn <= 0)
        {
            Spawn();
            timerSpawn = currentDifficulty;
        }

    }

    private void Timer()
    {
        timerSpawn -= Time.deltaTime;
    }

    private void Spawn()
    {
        for (int i = 0; i < obstaclesList.Count; i++)
        {

            if (!obstaclesList[i].activeInHierarchy)
            {
                obstaclesList[i].transform.position = transform.position;
                obstaclesList[i].transform.rotation = transform.rotation;
                obstaclesList[i].transform.localScale = transform.localScale;
                obstaclesList[i].SetActive(true);
                break;

            }
        }
     
    }


   


}
