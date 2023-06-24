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

    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        graph = wpManager.GetComponent<WaypointManager>().graph;

        currentNode = wps[0];
    }

    // Update is called once per frame
    void LateUpdate()
    {

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
            }

    }


    //public void GoToHelipad()
    //{

    //    graph.AStar(currentNode, wps[20]);
    //    currentWaypointIndex = 0;


    //}
    //public void GoToRuins()
    //{
    //    graph.AStar(currentNode, wps[7]);
    //    currentWaypointIndex = 0;


    //}
    //public void GoToFactory()
    //{ 
    //    graph.AStar(currentNode, wps[17]);
    //    currentWaypointIndex = 0;



    //}
    //public void GoToTwinMountains()
    //{
    //    graph.AStar(currentNode, wps[3]);
    //    currentWaypointIndex = 0;



    //}
    //public void GotoBarracks()
    //{
    //    graph.AStar(currentNode, wps[12]);
    //    currentWaypointIndex = 0;



    //}
    //public void GoToCommandCenter()
    //{
    //    graph.AStar(currentNode, wps[5]);
    //    currentWaypointIndex = 0;



    //}
    //public void GoToOilRefinery()
    //{
    //    graph.AStar(currentNode, wps[14]);
    //    currentWaypointIndex = 0;



    //}
    //public void GoToTankers()
    //{
    //    graph.AStar(currentNode, wps[16]);
    //    currentWaypointIndex = 0;



    //}
    //public void GoToRadar()
    //{
    //    graph.AStar(currentNode, wps[8]);
    //    currentWaypointIndex = 0;


    //}
    //public void GoToCommandPost()
    //{
    //    graph.AStar(currentNode, wps[6]);
    //    currentWaypointIndex = 0;



    //}
    //public void GoToMiddle()
    //{
    //    graph.AStar(currentNode, wps[13]);
    //    currentWaypointIndex = 0;



    //}
}
