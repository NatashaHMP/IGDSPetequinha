using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBuilder : MonoBehaviour {


    // DIFICULDADE
  
    private const float MAX_DIFFICULTY = 1f;
    private const float MIN_DIFFICULTY = 10f;

    private float timerSpawn;

    //OBSTACULOS
    public GameObject Birds
    {
        get { return birds; }
        set { birds = value; }
    }
    [SerializeField]
    private GameObject birds;


    private const int qntdObstacles = 6;
    private List<GameObject> obstaclesList;


    private void Start()
    {
        LoadResources();
    }


    private void LoadResources()
    {
        if (MainGameStatus.instance._currentDifficulty == 0)
        {
            MainGameStatus.instance._currentDifficulty = MIN_DIFFICULTY;
        }

       

        obstaclesList = new List<GameObject>();
        for (int i = 0; i < qntdObstacles; i++)
        {
            GameObject obj = (GameObject)Instantiate(birds);
           
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
            timerSpawn = Dificult();
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


    private float Dificult()
    {

        if (MainGameStatus.instance._currentDifficulty > MAX_DIFFICULTY)
        {
            MainGameStatus.instance._currentDifficulty = MainGameStatus.instance._currentDifficulty - 1f;
        }
       
        return MainGameStatus.instance._currentDifficulty;
    }


}
