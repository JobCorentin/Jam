using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{

    public GameObject TutorialPanel, Menu;
    public void OpenTuto()
    {
        TutorialPanel.SetActive(true);
        Menu.SetActive(false);
    }

    public void Back()
    {
        TutorialPanel.SetActive(false);
        Menu.SetActive(true);
    }

    public void LoadMainScene()
    {
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        StartCoroutine(FadeUI.fade.fadeIn());
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
