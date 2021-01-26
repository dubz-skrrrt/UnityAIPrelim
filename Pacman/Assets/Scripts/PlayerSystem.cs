using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerSystem : MonoBehaviour
{

    public AudioSource Chomp;

    public Text ScoreUI;
    private int score;

    public Text HealthUI;
    private int health = 3;
    
    private int ballcounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        ScoreUI.text = "" + score;
        HealthUI.text = "LIVES: " + health;
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "wall"){
            Debug.Log("wallcollider");
        }
    }
    void OnTriggerEnter (Collider col) {

        // if pacman collides with ball
        if (col.gameObject.tag == "Ball") {

            Chomp.Play();
            score += 100;
            ballcounter++;
            Destroy(col.gameObject);
            ScoreUI.text = "" + score;

            if (ballcounter == 202) { // checks if pacman ate all the balls

                ScoreMenu.scoretextstr = ScoreUI.text; // passes the score to the ScoreMenu scene
                SceneManager.LoadScene("ScoreMenu");
            } 
        }

        // if pacman collides with enemy
        if (col.gameObject.tag == "Enemy") {

            health--;
            //SceneManager.LoadScene("Game2"); // restarts the level

            if (health == 0) {
                
                ScoreMenu.scoretextstr = ScoreUI.text; // passes the score to the ScoreMenu scene
                SceneManager.LoadScene("ScoreMenu");
            } 
        }
    }

}
