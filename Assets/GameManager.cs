using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int startingLives = 3;
    private int currentLives;
    public TextMeshProUGUI livesText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentLives = startingLives;
        UpdateLivesUI();
    }

    public void DecreaseLives()
    {
        currentLives--;
        UpdateLivesUI();

        if (currentLives <= 0)
        {
            GameOver();
        }
        else
        {
           instance.RestartLevel();
        }
    }
    public void GainLife(int amount)
    {
        currentLives += amount;
        UpdateLivesUI();
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = ""+ currentLives;
        }
    }

    private void GameOver()
    {
        // Implement game over logic here
        Debug.Log("Game Over");
    }

    public int GetCurrentLives()
    {
        return currentLives;
    }
    public void RestartLevel()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
