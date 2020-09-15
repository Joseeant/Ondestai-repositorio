using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed;
    [HideInInspector]
    public Vector3 movement = Vector3.right;
    [HideInInspector]
    public bool move = true;
    [HideInInspector]
    public Rigidbody2D rigidBody2D;
    [HideInInspector]
    public Vector3 triggerPosition;

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
        }
    }
}
