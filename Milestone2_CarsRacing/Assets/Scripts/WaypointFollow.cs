using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    public UnityStandardAssets.Utility.WaypointCircuit circuit;

    int currentWaypointIdx = 0;

    float speed = 5;

    float rotSpeed = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (circuit.Waypoints.Length == 0) return;

        GameObject currentWaypoint = circuit.Waypoints[currentWaypointIdx].gameObject;

        Vector3 goal = new Vector3(currentWaypoint.transform.position.x, this.transform.position.y, currentWaypoint.transform.position.z);

        Vector3 direction = goal - this.transform.position;

        if (direction.magnitude < 1)
        {
            currentWaypointIdx++;

            if (currentWaypointIdx >= circuit.Waypoints.Length)
            {
                currentWaypointIdx = 0;
            }
        }

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
