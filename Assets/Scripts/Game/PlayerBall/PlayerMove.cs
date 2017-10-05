using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Rigidbody2D playerRb;
    private float speed = 5;
    private float horizontal;
    private Animator animator;
    private bool verifyRight;
    [SerializeField]
    private string objectTag;

    //CONTROLE MOBILE
    public GameObject ButtonDir
    {
        get { return ButtonDir; }
        set { ButtonDir = value; }
    }
    [SerializeField]
    private GameObject buttonDir;
    public GameObject ButtonEsq
    {
        get { return ButtonEsq; }
        set { ButtonEsq = value; }
    }
    [SerializeField]
    private GameObject buttonEsq;
    private PlayerController componentDir;
    private PlayerController componentEsq;

    private void Start()
    {
        componentDir = buttonDir.GetComponent<PlayerController>();
        componentEsq = buttonEsq.GetComponent<PlayerController>();

        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        verifyRight = transform.localScale.x > 0;
    }

    private void FixedUpdate()
    {
        ControlInput();
        Move();
        ChangeDirection(horizontal);
        
    }

    private void ControlInput()
    {
        if (Input.GetKey("d") || componentDir.input == 1)
        { 
            horizontal = 1;
        }
        else if (Input.GetKey("a") || componentEsq.input == 1)
        {
            horizontal = -1;
        }
        else
        {
            horizontal = 0;
        }
    }

    private void Move()
    {
            playerRb.velocity = new Vector2(horizontal * speed, playerRb.velocity.y);
            animator.SetFloat("walk", Mathf.Abs(horizontal));
    }

    private void ChangeDirection(float horizontal)
    {
        if (horizontal > 0 && !verifyRight || horizontal < 0 && verifyRight)
        {
            verifyRight = !verifyRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == objectTag)
        {
            animator.SetTrigger("kick");
        }


    }


}

