using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;


    void Start()
    {
        Time.timeScale = 1;
    }
    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void PlayButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void ReplayButton()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    /*
    IEnumerator Replay()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

    }

    IEnumerator Menu()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(0);
    }
    */
}
