using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionBehaviour : MonoBehaviour
{

    private PlayerBehaviour playerBehaviour;
    private Transform buttonsCanvas;
    public bool upEnabled;
    public bool rightEnabled;
    public bool leftEnabled;
    public bool downEnabled;

    // Start is called before the first frame update
    void Start()
    {
        playerBehaviour = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
        buttonsCanvas = GameObject.Find("ButtonsCanvas").transform;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Disable the correct button
        disableButtonOnEnter();

        //Activate canvas
        buttonsCanvas.GetChild(0).gameObject.SetActive(upEnabled);
        buttonsCanvas.GetChild(1).gameObject.SetActive(rightEnabled);
        buttonsCanvas.GetChild(2).gameObject.SetActive(leftEnabled);
        buttonsCanvas.GetChild(3).gameObject.SetActive(downEnabled);

        //Stop the player
        playerBehaviour.move = false;
        playerBehaviour.triggerPosition = transform.position;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //Disable the correct button
        disableButtonOnExit();
    }

    private void disableButtonOnEnter()
    {
        if (playerBehaviour.movement == Vector3.up)
        {
            downEnabled = false;
        }
        else if (playerBehaviour.movement == Vector3.right)
        {
            leftEnabled = false;
        }
        else if (playerBehaviour.movement == Vector3.left)
        {
            rightEnabled = false;
        }
        else
        {
            upEnabled = false;
        }
    }

    private void disableButtonOnExit()
    {
        if (playerBehaviour.movement == Vector3.up)
        {
            upEnabled = false;
        }
        else if (playerBehaviour.movement == Vector3.right)
        {
            rightEnabled = false;
        }
        else if (playerBehaviour.movement == Vector3.left)
        {
            leftEnabled = false;
        }
        else
        {
            downEnabled = false;
        }
    }
}
