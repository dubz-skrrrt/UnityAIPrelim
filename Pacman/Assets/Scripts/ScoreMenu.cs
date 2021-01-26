using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScoreMenu : MonoBehaviour
{
    public static string scoretextstr;
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = scoretextstr;
    }

    public void ReturnToMenu()
    {
         SceneManager.LoadScene("MainMenu"); // loads MainMenu scene
    }
}
