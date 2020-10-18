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
        //Así no se destruye el objeto
        DontDestroyOnLoad(this);
    }
    public void changeToGameOverScene(GameOverInfo gameOverInfo)
    {   
        //Se cambia de escena a la escena de Game Over
        this.gameOverInfo = gameOverInfo;
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }
    
}
