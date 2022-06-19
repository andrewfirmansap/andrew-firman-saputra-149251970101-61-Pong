using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Created by andrew - firman - saputra - 149251970101 - 61");
        
    }
    public void OpenCredit()
    {
        Debug.Log("Created by Andrew Firman");
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        //Debug.Log("Created by andrew - firman - saputra - 149251970101 - 61");
    }
}
