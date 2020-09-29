﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventBehaviour : MonoBehaviour
{
    private PlayerBehaviour playerBehaviour;
    public string introSentence;
    public Option option1;
    public Option option2;
    private Transform dialogueCanvas;

    // Start is called before the first frame update
    void Start()
    {
        playerBehaviour = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
        dialogueCanvas = GameObject.Find("DialogueCanvas").transform;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Stop the player
        playerBehaviour.move = false;
        playerBehaviour.triggerPosition = transform.position;

        if(playerBehaviour.comeFromShortcut)
        {
            playerBehaviour.shortcutBehaviour = gameObject.GetComponent<ShortcutBehaviour>();
        }

        dialogueCanvas.GetComponent<DialogueController>().launchDialogue(introSentence, option1, option2);
    }
}
