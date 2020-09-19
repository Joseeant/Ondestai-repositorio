using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [HideInInspector]
    public GameOverInfo gameOverInfo;
    [HideInInspector]
    public int currentScene;
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void changeToGameOverScene(GameOverInfo gameOverInfo)
    {
        this.gameOverInfo = gameOverInfo;
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }
    
}
