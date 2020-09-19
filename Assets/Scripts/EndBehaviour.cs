using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBehaviour : MonoBehaviour
{

    public GameOverInfo gameOverInfo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("GameOverController").GetComponent<GameOverController>().changeToGameOverScene(gameOverInfo);
    }
}
