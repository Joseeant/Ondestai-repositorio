using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed;
    public Vector3 movement;
    [HideInInspector]
    public bool move = true;
    [HideInInspector]
    public bool OneDirection = false;
    [HideInInspector]
    public Rigidbody2D rigidBody2D;
    [HideInInspector]
    public Vector3 triggerPosition;
    public int alcoholStatus;
    public int funStatus;
    public int moneyStatus;
    [HideInInspector]
    public Vector3 defaultMovement;
    //[HideInInspector]
    //public Animator animator;
    public GameOverInfo gameOverAlcoholMax;
    public GameOverInfo gameOverAlcoholMin;
    public GameOverInfo gameOverFunMax;
    public GameOverInfo gameOverFunMin;
    public GameOverInfo gameOverMoneyMax;
    public GameOverInfo gameOverMoneyMin;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        defaultMovement = Vector3.down;
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            //setAnimatorDirection();
            checkStats();
            rigidBody2D.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, triggerPosition, 0.01F);
            if(triggerPosition == transform.position)
            {
                if (OneDirection)
                {
                    move = true;
                    OneDirection = false;
                } else
                {
                    //animator.enabled = false;
                }
                
            }
        }

       
    }
/*
    public void setAnimatorDirection()
    {
        if (movement == Vector3.up)
            animator.SetInteger("direction", 0);
        if (movement == Vector3.right)
            animator.SetInteger("direction", 1);
        if (movement == Vector3.left)
            animator.SetInteger("direction", 2);
        if (movement == Vector3.down)
            animator.SetInteger("direction", 3);
    }
*/
    public void checkStats()
    {
        if(alcoholStatus <= 0)
        {
            GameObject.Find("GameOverController").GetComponent<GameOverController>()
                .changeToGameOverScene(gameOverAlcoholMin);
        }
        else if (alcoholStatus >= 10)
        {
            GameObject.Find("GameOverController").GetComponent<GameOverController>()
                .changeToGameOverScene(gameOverAlcoholMax);
        }
        else if (funStatus <= 0)
        {
            GameObject.Find("GameOverController").GetComponent<GameOverController>()
                .changeToGameOverScene(gameOverFunMin);
        }
        else if (funStatus >= 10)
        {
            GameObject.Find("GameOverController").GetComponent<GameOverController>()
                .changeToGameOverScene(gameOverFunMax);
        }
        else if (moneyStatus <= 0)
        {
            GameObject.Find("GameOverController").GetComponent<GameOverController>()
                .changeToGameOverScene(gameOverMoneyMin);
        }
        else if (moneyStatus >= 10)
        {
            GameObject.Find("GameOverController").GetComponent<GameOverController>()
                .changeToGameOverScene(gameOverMoneyMax);
        }
    }
}
