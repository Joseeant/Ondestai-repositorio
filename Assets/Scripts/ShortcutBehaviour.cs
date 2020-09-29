using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutBehaviour : MonoBehaviour
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
        buttonsCanvas = GameObject.Find("ButtonsCanvas").transform;
        playerBehaviour = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
    }

    public void activateButtons()
    {
        buttonsCanvas.GetChild(0).gameObject.SetActive(upEnabled);
        buttonsCanvas.GetChild(1).gameObject.SetActive(rightEnabled);
        buttonsCanvas.GetChild(2).gameObject.SetActive(leftEnabled);
        buttonsCanvas.GetChild(3).gameObject.SetActive(downEnabled);
    }
}
