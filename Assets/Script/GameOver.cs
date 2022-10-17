using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    void Start()
    {
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    public void GameOverOn(){
        gameOverUI.SetActive(true);
    }

    public void Retry()
    {
        int currentGameSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentGameSceneIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
