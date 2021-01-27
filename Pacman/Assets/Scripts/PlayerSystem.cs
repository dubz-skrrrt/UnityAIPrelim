using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerSystem : MonoBehaviour
{

    public AudioSource Chomp;
    public AudioSource PlayerHit;
    public bool PowerUp;

    private Color originalColor;
    public Text ScoreUI;
    private int score;
    public int health;
    private GameObject player;
    private Vector3 playerPos;
    private int ballcounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = this.gameObject.GetComponent<Renderer>().material.color;
        ScoreUI.text = "" + score;
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
            ScoreUI.text = "" + score;

            if (ballcounter == 198) { // checks if pacman ate all the balls

                ScoreMenu.scoretextstr = ScoreUI.text; // passes the score to the ScoreMenu scene
                SceneManager.LoadScene("ScoreMenu");
            } 
        }

        // if pacman collides with enemy
        if (col.gameObject.tag == "GhostEnemy") {
            
            health = GameObject.FindGameObjectWithTag("Lives").GetComponent<Lives>().Life -= 1;
            //Debug.Log(health);
            
            StartCoroutine(KillEvent());
            if (health == 0) {
                
                ScoreMenu.scoretextstr = ScoreUI.text; // passes the score to the ScoreMenu scene
                SceneManager.LoadScene("ScoreMenu");
            } 
        }
    }
    IEnumerator PowerUpevent(){
        yield return new WaitForSeconds(5f);
        PowerUp = false;
        this.gameObject.GetComponent<Renderer>().material.color =originalColor;
        Debug.Log("PowerupFaded");
    }
    IEnumerator KillEvent(){
        
        PlayerHit.Play();
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1f);
        
        Destroy(player);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        
        
        // playerPos = GameObject.Find("RespawnBase").transform.position;
        // Instantiate(player, playerPos, Quaternion.identity);
    }

}
