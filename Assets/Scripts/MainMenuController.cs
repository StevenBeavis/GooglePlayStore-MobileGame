using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject StorePanel;

    

    void Start() 
    {
        Time.timeScale = 1;
        Cursor.visible = true; 

    }

    public void StartGame() 
    { 
        StartCoroutine(SceneDelay()); 
    }

    public void StoreClick()
    {
        MainMenuPanel.SetActive(false);
        StorePanel.SetActive(true);
    }

    public void BackButton()
    {
        StorePanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    IEnumerator SceneDelay() 
    { 
        yield return new WaitForSeconds(1); 
        SceneManager.LoadScene(1); }
}
