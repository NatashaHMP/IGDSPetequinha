using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    private float velocity;
    private const float timeLife = 3;



    private void OnEnable()
    {
        Invoke("DisableObj", timeLife);
        transform.position = new Vector3(SetLocalSpawn(), Random.Range(4.45f, -0.98f));
        SetVelocity();
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        if (velocity > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        } 
    }


    private float SetLocalSpawn()
    {
        var local = Random.Range(0, 2);
        if(local == 0)
        {
            return -5;
        }else
        {
            return 5;
        }
    }

    private void SetVelocity()
    {
        if (transform.position.x < 0)
        {
            velocity = -3.5f;
        }
        else
        {
            velocity = 3.5f;
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



}
