//using System.Diagnostics;
using UnityEngine;

public class PauseMENU : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();

            }
        }
    }

    public void Resume()
    {

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("resumed game");

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit game");
    }

}
