using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
   public void PlayGame()
   {
       SceneManager.LoadScene("PacmanGame");
   }
   
   public void ExitGame()
    {
        Debug.Log ("The application is now closed");
        Application.Quit();
    }
}
