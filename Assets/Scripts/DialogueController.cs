using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueController : MonoBehaviour
{
    public Image image;
    public Text mainText;
    public Text option1Text;
    public Text option2Text;
    public Button ContinueButton;
    [HideInInspector]
    public Option option1;
    [HideInInspector]
    public Option option2;
    [HideInInspector]
    public Option optionSelected;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        optionSelected = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void launchDialogue(string introSentence, Option option1, Option option2)
    {
        foreach (Transform child in transform)
        {
            if (child.name != "Image" && child.name != "ContinueButton")
                child.gameObject.SetActive(true);
        }
        this.option1 = option1;
        this.option2 = option2;
        mainText.text = introSentence;
        option1Text.text = option1.buttonText;
        option2Text.text = option2.buttonText;
    }

    public void onClickOk()
    {
        if (optionSelected != null)
        {
            mainText.text = optionSelected.resultText;
            image.gameObject.SetActive(true);
            image.sprite = optionSelected.image;
            ContinueButton.gameObject.SetActive(true);
            GameObject.Find("Option1Button").SetActive(false);
            GameObject.Find("Option2Button").SetActive(false);
            GameObject.Find("OkButton").SetActive(false);
        }
    }

    public void onClickContinuar()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        PlayerBehaviour playerBehaviour = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
        playerBehaviour.alcoholStatus += optionSelected.alcoholModifier;
        playerBehaviour.funStatus += optionSelected.funModifier;
        playerBehaviour.moneyStatus += optionSelected.moneyModifier;
        playerBehaviour.move = true;
        //playerBehaviour.animator.enabled = true;

        if (optionSelected.activateShortcut)
        {
            playerBehaviour.movement = optionSelected.direction;
            playerBehaviour.comeFromShortcut = true;
        }
        else
        {
            if (playerBehaviour.comeFromShortcut)
            {
                playerBehaviour.shortcutBehaviour.activateButtons();
                playerBehaviour.move = false;
            }

            playerBehaviour.comeFromShortcut = false;
            
        }

        optionSelected = null;


    }
}
