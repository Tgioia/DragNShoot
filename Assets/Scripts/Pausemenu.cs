using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject audioMenuUI;
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void Audio()
    {
        pauseMenuUI.SetActive(false);
        audioMenuUI.SetActive(true);
    }
    public void BackAudio()
    {
        pauseMenuUI.SetActive(true);
        audioMenuUI.SetActive(false);
    }
    public void GameOver()
    {
        Time.timeScale = 1f;
        gameIsPaused =false;
        pauseMenuUI.SetActive(false);
        GameManager.instance.GameOver();   
    }
}
