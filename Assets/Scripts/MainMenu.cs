using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject startMenuUI;
    public GameObject optionsMenuUI;
    public void PlayGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void OpenOptions()
    {
        optionsMenuUI.SetActive(true);
        startMenuUI.SetActive(false);
        PauseMenu.isOptions = true;
    }

    public void CloseOptions()
    {
        optionsMenuUI.SetActive(false);
        startMenuUI.SetActive(true);
        PauseMenu.isOptions = false;
    }
}
