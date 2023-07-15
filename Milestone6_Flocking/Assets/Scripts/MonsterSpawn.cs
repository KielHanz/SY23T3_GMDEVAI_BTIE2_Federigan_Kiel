using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject fleeObstacle;
    public GameObject flockObstacle;
    GameObject[] agents;
    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("agent");
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin ,ray.direction, out hit)) 
            { 
                Instantiate(fleeObstacle, hit.point, fleeObstacle.transform.rotation);
                foreach (GameObject a in agents)
                {
                    a.GetComponent<AiControl>().DetectFleeObstacle(hit.point);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                Instantiate(flockObstacle, hit.point, flockObstacle.transform.rotation);
                foreach(GameObject a in agents)
                {
                    a.GetComponent<AiControl>().DetectFlockObstacle(hit.point);
                }

            }
        }
    }
}
