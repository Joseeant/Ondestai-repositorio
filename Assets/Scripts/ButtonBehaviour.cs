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

    public void onClick(GameObject button)
    {
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

        playerBehaviour.movement = movement;
        playerBehaviour.move = true;

        foreach(Transform childButton in transform)
        {
            childButton.gameObject.SetActive(false);
        }
    }
}
