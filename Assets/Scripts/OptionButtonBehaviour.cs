using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButtonBehaviour : MonoBehaviour
{

    DialogueController dialogueController;

    // Start is called before the first frame update
    void Start()
    {
        dialogueController = FindObjectOfType<DialogueController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickOption()
    {
        switch (name)
        {
            case "Option1Button":
                dialogueController.optionSelected = dialogueController.option1;
                break;

            case "Option2Button":
                dialogueController.optionSelected = dialogueController.option2;
                break;
        }
    }
}
