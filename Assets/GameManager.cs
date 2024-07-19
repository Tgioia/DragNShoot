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
    public TextMeshProUGUI pointsText;
    public int punti;
    public TextMeshProUGUI LevelName;
    [SerializeField] private AudioSource gameOverFX;

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
    }
    private void Start()
    {
        currentLives = startingLives;
        UpdateLivesUI();
        punti = 0;
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
    }public void UpdatePointsUI()
    {
        if (pointsText != null)
        {
            pointsText.text = ""+ punti;
        }
    }
    public int GetLives()
    {
        return currentLives;
    }
 

    public void GameOver()
    {
        GameManager.instance.livesText.gameObject.SetActive(false);
        gameOverFX.Play();
        SceneManager.LoadScene("GameOverMenu");
    }
    public void SetPoints()
    {
        punti = 0;
        UpdatePointsUI();

    }
    public int getPoints()
    {
        return punti;
    }
    public void ResetLives()
    {
        currentLives = startingLives;
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
        return !sceneName.Equals("Menu") && !sceneName.Equals("Tutorial1")&&!sceneName.Equals("Tutorial2")&&!sceneName.Equals("Tutorial3")&&!sceneName.Equals("CharacterSelection")&&!sceneName.Equals("GameOverMenu"); 
    }
    public Sprite getSkin()
    {
        return playerSprite;
    }
    public void setSkin(Sprite skin)
    {
        playerSprite = skin;
    }
    public void setLevelName()
    {
        this.LevelName.text = SceneManager.GetActiveScene().ToString();
    }
}
