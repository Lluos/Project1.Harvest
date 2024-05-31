using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1MenuController : MonoBehaviour
{
    public GameObject instPanel;
    public GameObject menuPanel;

    public void ExitMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowMenu()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(!menuPanel.activeSelf);
        }
    }

    public void HideInstPanel()
    {
        instPanel.SetActive(false);
    }
}
