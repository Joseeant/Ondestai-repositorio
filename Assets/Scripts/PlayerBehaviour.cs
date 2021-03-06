﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed;
    public Vector2 movement;
    [HideInInspector]
    public bool move = true;
    [HideInInspector]
    public bool OneDirection = false;
    [HideInInspector]
    public Rigidbody2D rigidBody2D;
    [HideInInspector]
    public Vector2 triggerPosition;
    public int moneyStatus;
    public int alcoholStatus;
    public int funStatus;

    [HideInInspector]
    public bool godModeOn = false;

    [HideInInspector]
    public bool onPause = false;
    //[HideInInspector]
    //public Animator animator;
    public GameOverInfo gameOverMoneyMax;
    public GameOverInfo gameOverMoneyMin;
    public GameOverInfo gameOverAlcoholMax;
    public GameOverInfo gameOverAlcoholMin;
    public GameOverInfo gameOverFunMax;
    public GameOverInfo gameOverFunMin;
    [HideInInspector]
    public bool comeFromShortcut;
    [HideInInspector]
    public ShortcutBehaviour shortcutBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Se comprueba si el juego está en pausa
        if (!onPause)
        {
            //Si no está en pausa, comprueba si se tiene que mover o no
            if (move)
            {
                //setAnimatorDirection();
                //Se comprueba si se ha perdido por stats y se mueve en la dirección correspondiente
                checkStats();
                rigidBody2D.MovePosition(rigidBody2D.position + movement * speed * Time.fixedDeltaTime);
            }
            else
            {
                //Si no se tiene que mover, se sitúa en la misma posición que el trigger que lo paró
                rigidBody2D.position = Vector2.MoveTowards(rigidBody2D.position, triggerPosition, 0.05F);
                if (triggerPosition == rigidBody2D.position)
                {
                    //Si solo hay una dirección, se mueve en esa dirección automáticamente
                    if (OneDirection)
                    {
                        move = true;
                        OneDirection = false;
                    }
                    else
                    {
                        //animator.enabled = false;
                    }

                }
            }
        }
        else
        {
            //animator.enabled = false;
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
    public bool checkStats()
    {
        //Se comprueba cada una de las stats y si se pierde con alguna, cambia a la pantalla de Game Over
        bool gameOver = false;
        if (!godModeOn)
        {
            if (alcoholStatus <= 0)
            {
                GameObject.Find("GameOverController").GetComponent<GameOverController>()
                    .changeToGameOverScene(gameOverAlcoholMin);
                gameOver = true;
            }
            else if (alcoholStatus >= 10)
            {
                GameObject.Find("GameOverController").GetComponent<GameOverController>()
                    .changeToGameOverScene(gameOverAlcoholMax);
                gameOver = true;
            }
            else if (funStatus <= 0)
            {
                GameObject.Find("GameOverController").GetComponent<GameOverController>()
                    .changeToGameOverScene(gameOverFunMin);
                gameOver = true;
            }
            else if (funStatus >= 10)
            {
                GameObject.Find("GameOverController").GetComponent<GameOverController>()
                    .changeToGameOverScene(gameOverFunMax);
                gameOver = true;
            }
            else if (moneyStatus <= 0)
            {
                GameObject.Find("GameOverController").GetComponent<GameOverController>()
                    .changeToGameOverScene(gameOverMoneyMin);
                gameOver = true;
            }
            else if (moneyStatus >= 10)
            {
                GameObject.Find("GameOverController").GetComponent<GameOverController>()
                    .changeToGameOverScene(gameOverMoneyMax);
                gameOver = true;
            }
        }

        return gameOver;
    }

    public void godModeButton() {
        godModeOn = !godModeOn;
        GameObject.Find("GodCanvas").transform.GetChild(1).gameObject.SetActive(godModeOn);
        
    }
}
