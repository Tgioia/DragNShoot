using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    [SerializeField] private AudioSource firstShotFX;
    [SerializeField] private AudioSource successFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "Ball")
        {
            if (GameManager.instance.firstTry&&GameManager.instance.IsGameplayLevel())
            {
                Debug.Log("Finish, first try");
                firstShotFX.Play();
                GameManager.instance.GainLife(3);
                GameManager.instance.punti += 50;
                GameManager.instance.UpdatePointsUI();
            }
            else if (GameManager.instance.IsGameplayLevel())
            {
                successFX.Play();
                GameManager.instance.GainLife(1);
                GameManager.instance.punti += 25;
                GameManager.instance.UpdatePointsUI();
            }
            Debug.Log("Win");
            GameManager.instance.firstTry = true;
            if (SceneManager.GetActiveScene().name == "Tutorial3" || SceneManager.GetActiveScene().name == "Level05")
            {
                SceneManager.LoadScene("Menu");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
