using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerSystem : MonoBehaviour
{

    public AudioSource Chomp;
    public bool GhostEaten;
    public bool PowerUp;
    public Text ScoreUI;
    private int score;
    public int health;
    private Color originalColor;
    private GameObject player;
    private Vector3 playerPos;
    private int ballcounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = this.gameObject.GetComponent<Renderer>().material.color;
        ScoreUI.text = "SCORE: " + score;
        player = GameObject.Find("Pacman");
        
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "wall"){
            Debug.Log("wallcollider");
        }
    }
    void OnTriggerEnter (Collider col) {

        if (col.gameObject.tag == "PowerUpPellets"){
            PowerUp = true;
            Destroy(col.gameObject);
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(PowerUpevent());
        }
        // if pacman collides with ball
        if (col.gameObject.tag == "Ball") {

            Chomp.Play();
            score += 100;
            ballcounter++;
            Destroy(col.gameObject);
            ScoreUI.text = "SCORE: " + score;

            if (ballcounter == 202) { // checks if pacman ate all the balls

                ScoreMenu.scoretextstr = ScoreUI.text; // passes the score to the ScoreMenu scene
                SceneManager.LoadScene("ScoreMenu");
            } 
        }

        // if pacman collides with enemy
        if (col.gameObject.tag == "GhostEnemy") {
            if (PowerUp){
                Debug.Log(PowerUp);
                //score += 200;
                GhostEaten = true;
                // if (GhostEaten == true){
                //     col.gameObject.transform.position = GameObject.FindGameObjectWithTag("GhostEnemy").GetComponent<EnemyAI>().RespawnPoint;
                // }
            }else{
                Debug.Log("hit");
                health = GameObject.FindGameObjectWithTag("Lives").GetComponent<Lives>().Life -= 1;
                StartCoroutine(KillEvent());
                if (health == 0) {
                    
                    ScoreMenu.scoretextstr = ScoreUI.text; // passes the score to the ScoreMenu scene
                    SceneManager.LoadScene("ScoreMenu");
                } 
            }
            
            //Debug.Log(health);
            
            
        }
    }

    IEnumerator PowerUpevent(){
        yield return new WaitForSeconds(5f);
        PowerUp = false;
        this.gameObject.GetComponent<Renderer>().material.color =originalColor;
        Debug.Log("PowerupFaded");
    }
    IEnumerator KillEvent(){
        
        yield return new WaitForSeconds(0f);
        Destroy(player);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        // playerPos = GameObject.Find("RespawnBase").transform.position;
        // Instantiate(player, playerPos, Quaternion.identity);
    }

}
