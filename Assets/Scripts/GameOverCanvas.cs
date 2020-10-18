using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{

    private int previousScene;

    // Start is called before the first frame update
    void Start()
    {   
        //se obtiene la información y se muestra en la pantalla
        GameObject gameOverController = GameObject.Find("GameOverController");
        GameOverInfo gameOverInfo = gameOverController.GetComponent<GameOverController>().gameOverInfo;
        previousScene = gameOverController.GetComponent<GameOverController>().currentScene;
        Destroy(GameObject.Find("GameOverController"));

        transform.GetChild(0).gameObject.GetComponent<Text>().text = gameOverInfo.text;
        transform.GetChild(1).gameObject.GetComponent<Image>().sprite = gameOverInfo.sprite;
    }

    //Función que se ejecuta al pulsar el botón de reintentar
    public void retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(previousScene);
    }
}
