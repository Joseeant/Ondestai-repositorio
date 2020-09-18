﻿using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            rigidBody2D.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, triggerPosition, 0.03F);
            if(OneDirection && triggerPosition == transform.position)
            {
                move = true;
                OneDirection = false;
            }
        }
    }
}
