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
    private bool isTutorialScene;


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
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isTutorialScene = scene.name == "Menu"|| scene.name == "Tutorial01"||scene.name == "Tutorial02";




        if (!isTutorialScene)
        {
            livesText.gameObject.SetActive(true);
            currentLives = startingLives;
            UpdateLivesUI();
        }
        else
        {
            livesText.gameObject.SetActive(false); // Deactivate Lives UI in tutorial scene
        }
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
    private bool IsGameplayLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        return !sceneName.Equals("Menu") && !sceneName.Equals("Tutorial1")&&!sceneName.Equals("Tutorial2"); 
    }
}
