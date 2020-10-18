using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{

    Vector3 movement;
    PlayerBehaviour playerBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        playerBehaviour = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
    }

    //Función que se ejecuta cuando se pulsa una flecha de dirección
    public void onClick(GameObject button)
    {   
        //En función del nombre se indica la dirección correspondiente
        switch (button.name)
        {
            case "UpButton":
                movement = Vector3.up;
                break;

            case "RightButton":
                movement = Vector3.right;
                break;

            case "LeftButton":
                movement = Vector3.left;
                break;

            case "DownButton":
                movement = Vector3.down;
                break;
        }

        //Se indica la dirección en la que se tiene que mover
        playerBehaviour.movement = movement;
        playerBehaviour.move = true;
        //playerBehaviour.animator.enabled = true;

        //Se desactivan los botones
        foreach(Transform childButton in transform)
        {
            childButton.gameObject.SetActive(false);
        }
    }
}
