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
    public bool firstTry = true;//resettare ogni volta che cambi livello

    public Sprite playerSprite;

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
        /*if (IsGameplayLevel())
                {
                    livesText.gameObject.SetActive(true);
                    currentLives = startingLives;
                    UpdateLivesUI();
                }
                else
                {
                    livesText.gameObject.SetActive(false); // Deactivate Lives UI in tutorial scene
                }*/

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

    public void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = ""+ currentLives;
        }
    }
 

    public void GameOver()
    {
        instance.livesText.gameObject.SetActive(false);
        Debug.Log("Game Over");
        currentLives = startingLives; 
        UpdateLivesUI();
        SceneManager.LoadScene("Menu");
    }

    public int GetCurrentLives()
    {
        return currentLives;
    }
    public void RestartLevel()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public bool IsGameplayLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        return !sceneName.Equals("Menu") && !sceneName.Equals("Tutorial1")&&!sceneName.Equals("Tutorial2")&&!sceneName.Equals("CharacterSelection"); 
    }
    public Sprite getSkin()
    {
        return playerSprite;
    }
    public void setSkin(Sprite skin)
    {
        playerSprite = skin;
    }
}
