using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    private PlayerBehaviour playerBehaviour;
    public GameObject pauseButtonCanvas;
    public GameObject pauseMenuCanvas;

    void Start()
    {
        playerBehaviour = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
    }

    public void onClickPause()
    {
        playerBehaviour.onPause = true;
        pauseButtonCanvas.SetActive(false);
        pauseMenuCanvas.SetActive(true);
    }

    public void onClickContinue() {
        playerBehaviour.onPause = false;
        pauseButtonCanvas.SetActive(true);
        pauseMenuCanvas.SetActive(false);
    }

}
