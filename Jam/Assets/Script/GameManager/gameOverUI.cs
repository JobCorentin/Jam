using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverUI : MonoBehaviour
{
    public static gameOverUI gameOver;
    public GameObject gameOverUi, VictoryUi;

    private void Awake()
    {
        gameOver = this;
    }
    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ActivateGameOver()
    {
        gameOverUi.SetActive(true);
    }
    public void ActivateVictory()
    {
        VictoryUi.SetActive(true);
    }
}
