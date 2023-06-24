using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public Transform goal;

    float speed = 5.0f;
    float accuracy = 1.0f;
    float rotSpeed = 2.0f;

    public GameObject wpManager;

    [HideInInspector]public GameObject[] wps;
    public GameObject currentNode;

    public int currentWaypointIndex = 0;

    public Graph graph;

    public bool isCurrentSelectedTank;
    public bool isArrived;
    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        graph = wpManager.GetComponent<WaypointManager>().graph;

        currentNode = wps[0];
        isCurrentSelectedTank = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (!isCurrentSelectedTank)
        {
            return;
        }
        if (graph.getPathLength() == 0 ||currentWaypointIndex == graph.getPathLength())
        {
            return;
        }

       currentNode = graph.getPathPoint(currentWaypointIndex);


            if (Vector3.Distance(graph.getPathPoint(currentWaypointIndex).transform.position,transform.position) < accuracy)
            {
           currentWaypointIndex++;
            }

            if (currentWaypointIndex < graph.getPathLength())
            {
            goal = graph.getPathPoint(currentWaypointIndex).transform;


                Vector3 targetGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
                Vector3 direction = targetGoal - transform.position;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

            transform.Translate(0, 0, speed * Time.deltaTime);
            isArrived = false;
            }
            else if (currentWaypointIndex >= graph.getPathLength())
        {
            isArrived = true;
        }


    }

}
