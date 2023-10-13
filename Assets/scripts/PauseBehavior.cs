using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBehavior : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseMenu;
    public GameObject deathScreen;
    public GameObject hud;
    // Start is called before the first frame update
    void Start()
    {
        ResumeGame(); // Ensure time scale is 1
        pauseMenu.SetActive(false); // Pause menu disabled by default
        deathScreen.SetActive(false);
        hud.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Cancel button (Default: ESC) will be used to pause the game
        if (Input.GetButtonDown("Cancel"))
        {
            if(isPaused)
            {
                ResumeGame();
            } else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        hud.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        hud.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GotoMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnDeath()
    {
        hud.SetActive(false);
        deathScreen.SetActive(true);
    }

    public void Retry()
    {
        Scene sc = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sc.name);
    }
}
