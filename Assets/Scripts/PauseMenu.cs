using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject menuPanel;
    public GameObject menuBackground;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void OpenOptions() 
    {
        optionsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void CloseOptions() 
    {
        GameManager.instance.SaveOptions();
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        menuBackground.SetActive(false);
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ReturnToMain() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void Pause()
    {
        menuPanel.SetActive(true);
        menuBackground.SetActive(true);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitGame() 
    {
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        menuBackground.SetActive(false);
        //GameManager.instance.GameOver();
        Application.Quit();
    }
}
