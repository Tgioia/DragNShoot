using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level01");
    }
    public void StartTutorial()
    {
         SceneManager.LoadScene("Tutorial1");
    }
    public void SkinSelection()
    {
        SceneManager.LoadScene("CharacterSelection");
    }
    public void Login()
    {
        SceneManager.LoadScene("LoginMenu");
    }
}
