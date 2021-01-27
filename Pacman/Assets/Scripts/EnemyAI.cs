using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    private Transform goal;
    public GameObject ghostRespawn;
    public Vector3 RespawnPoint;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ghostRespawn = GameObject.FindGameObjectWithTag("GhostRespawn");
        RespawnPoint = ghostRespawn.transform.position;
        Debug.Log(RespawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        goal = player.transform;
        agent.destination = goal.position;
    }

    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "Player" && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSystem>().PowerUp == true){
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSystem>().GhostEaten == true){
                this.gameObject.transform.position = RespawnPoint;
            }
        }
        
    }
}
