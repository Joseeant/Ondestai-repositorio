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
        //Se desactiva el botón correspondiente
        disableButtonOnEnter();

        int count = 0;
        Vector3 movement = new Vector3();
        if (upEnabled)
        {
            movement = Vector2.up;
            count++;
        }
        if (rightEnabled)
        {
            movement = Vector2.right;
            count++;
        }
        if (leftEnabled)
        {
            movement = Vector2.left;
            count++;
        }
        if (downEnabled)
        {
            movement = Vector2.down;
            count++;
        }

        //Si solo se tiene que mover en una dirección, se mueve automáticamente
        if (count == 1)
        {
            playerBehaviour.movement = movement;
            playerBehaviour.triggerPosition = transform.position;
            playerBehaviour.OneDirection = true;
            playerBehaviour.move = false;
            return;
        }

        //Se activa el canvas
        if (playerBehaviour.godModeOn)
        {
            buttonsCanvas.GetChild(0).gameObject.SetActive(true);
            buttonsCanvas.GetChild(1).gameObject.SetActive(true);
            buttonsCanvas.GetChild(2).gameObject.SetActive(true);
            buttonsCanvas.GetChild(3).gameObject.SetActive(true);
        }
        else
        {
            buttonsCanvas.GetChild(0).gameObject.SetActive(upEnabled);
            buttonsCanvas.GetChild(1).gameObject.SetActive(rightEnabled);
            buttonsCanvas.GetChild(2).gameObject.SetActive(leftEnabled);
            buttonsCanvas.GetChild(3).gameObject.SetActive(downEnabled);
        }

        //Se para al jugador
        playerBehaviour.move = false;
        playerBehaviour.triggerPosition = transform.position;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //Se desactiva el botón correspondiente
        disableButtonOnExit();
    }

    private void disableButtonOnEnter()
    {
        if (playerBehaviour.movement == Vector2.up)
        {
            downEnabled = false;
        }
        else if (playerBehaviour.movement == Vector2.right)
        {
            leftEnabled = false;
        }
        else if (playerBehaviour.movement == Vector2.left)
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
        if (playerBehaviour.movement == Vector2.up)
        {
            upEnabled = false;
        }
        else if (playerBehaviour.movement == Vector2.right)
        {
            rightEnabled = false;
        }
        else if (playerBehaviour.movement == Vector2.left)
        {
            leftEnabled = false;
        }
        else
        {
            downEnabled = false;
        }
    }
}
