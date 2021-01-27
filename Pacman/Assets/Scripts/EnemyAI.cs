using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public GameObject[] GhostBlanket;
    public Color[] originalColor;
    private Transform goal;
    private Transform ghostRespawn;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GhostBlanket = GameObject.FindGameObjectsWithTag("GhostColor");
        
        originalColor = new Color[GhostBlanket.Length];
        for (int i = 0; i < GhostBlanket.Length; i++){
            originalColor[i] = GhostBlanket[i].GetComponent<Renderer>().material.color;
        }

    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSystem>().PowerUp);
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSystem>().PowerUp == true){
            Debug.Log("SLow");
            agent.speed = 10f;
            foreach(GameObject blankets in GhostBlanket){
                blankets.GetComponent<Renderer>().material.color = Color.blue;
            }
            
        }else{
            agent.speed = 30f;
            for (int i = 0; i < GhostBlanket.Length; i++){
            GhostBlanket[i].GetComponent<Renderer>().material.color = originalColor[i];
        }
        }
        goal = player.transform;
        agent.destination = goal.position;
    }
}
