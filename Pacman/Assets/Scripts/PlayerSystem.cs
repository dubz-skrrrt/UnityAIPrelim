using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerSystem : MonoBehaviour
{

    public Text ScoreUI;
    private int score;

    public Text HealthUI;
    private int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        ScoreUI.text = "SCORE: " + score;
        HealthUI.text = "LIVES: " + health;
    }

    void OnTriggerEnter (Collider col) {

        // if pacman collides with ball
        if (col.gameObject.tag == "Ball") {

            score += 100;
            Destroy(col.gameObject);
            ScoreUI.text = "SCORE: " + score;
        }

        // if pacman collides with enemy
        if (col.gameObject.tag == "Enemy") {

            health--;
            SceneManager.LoadScene("Game2"); // restarts the level

            if (health == 0) {
                
                ScoreMenu.scoretextstr = ScoreUI.text; // passes the score to the ScoreMenu scene
                SceneManager.LoadScene("ScoreMenu");
            } 
        }
    }

}
