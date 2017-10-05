using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountScore : MonoBehaviour {
    [SerializeField]
    private string objectTag;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == objectTag)
        {
            MainGameStatus.instance._score = MainGameStatus.instance._score + 1;
           
        }


    }
}
