using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "Ball")
        {
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
