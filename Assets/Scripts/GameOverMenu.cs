using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = scoreText.text + (GameManager.instance.getPoints() + GameManager.instance.GetLives() * 50);
            ;
           
    }
    public void MainMenu()
    {
        GameManager.instance.SetPoints();
        //gestione punti gameover->(reset etc)
        GameManager.instance.firstTry = true;
        GameManager.instance.ResetLives();
        GameManager.instance.UpdateLivesUI();
        SceneManager.LoadScene("Menu");
    }

}
