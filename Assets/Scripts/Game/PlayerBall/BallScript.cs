using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    private Rigidbody2D ballRb;
    [SerializeField]
    private float X;
    [SerializeField]
    private float Y;
    [SerializeField]
    private string playerTag;
    [SerializeField]
    private string obstacleTag;
    [SerializeField]
    private string bonusTag;
    [SerializeField]
    private string groundTag;

    [SerializeField]
    private AudioSource kickSound;
    [SerializeField]
    private AudioSource bonusSound;

    private const int maxDirection = 30;
    private const int ballForce = 65;


    private void Start () {
        ballRb = GetComponent<Rigidbody2D>();
    
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == playerTag || collision.gameObject.tag == obstacleTag)
        {

            kickSound.Play();
            int randomDirection = Random.Range(0, 2);
            if(randomDirection == 0)
            {
                randomDirection = -maxDirection;
            }
            else
            {
                randomDirection = maxDirection;
            }
            ballRb.AddForce(new Vector2(randomDirection, ballForce));
            
        } else if(collision.gameObject.tag == groundTag)
        {
            MainGameStatus.instance._gameisRun = false;
        } 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == bonusTag)
        {
            bonusSound.Play();
            MainGameStatus.instance._coin = MainGameStatus.instance._coin + 1;
            
        }
    }



}
