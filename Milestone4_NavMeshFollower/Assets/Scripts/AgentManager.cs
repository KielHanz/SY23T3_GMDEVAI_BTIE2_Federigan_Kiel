using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    private GameObject[] agents;
    private GameObject player;
    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("AI");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
        foreach (GameObject ai in agents)
       {
            ai.GetComponent<AIControl>().agent.SetDestination(player.transform.position);
       }
            
    }
}
