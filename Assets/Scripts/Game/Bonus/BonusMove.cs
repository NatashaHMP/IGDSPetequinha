using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMove : MonoBehaviour {

    private float velocity;
    private const float timeLife = 2f;
    [SerializeField]
    private string objectTag;


    private void OnEnable()
    {
        Invoke("DisableObj", timeLife);
        transform.position = new Vector3(SetLocalSpawn(), Random.Range(2.7f, -0.98f));
        SetVelocity();
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        if (velocity > 0)
        {
            transform.localScale = new Vector3(-0.7238573f, 0.7238573f, 0.7238573f);
        }
        else
        {
            transform.localScale = new Vector3(0.7238573f, 0.7238573f, 0.7238573f);
        }
    }


    private float SetLocalSpawn()
    {
        var local = Random.Range(0, 2);
        if (local == 0)
        {
            return -5;
        }
        else
        {
            return 5;
        }
    }

    private void SetVelocity()
    {
        if (transform.position.x < 0)
        {
            velocity = -5;
        }
        else
        {
            velocity = 5;
        }
    }


    private void DisableObj()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void FixedUpdate()
    {
        transform.position -= new Vector3(velocity, 0, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }


}
