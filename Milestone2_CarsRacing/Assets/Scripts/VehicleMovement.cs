using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public Transform goal;

    public float speed = 0;
    public float rotSpeed = 1;

    public float accelerate = 5;
    public float decelerate = 5;

    public float minSpeed = 0;
    public float maxSpeed = 20;

    public float breakAngle = 20;


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 target = new Vector3(goal.transform.position.x, goal.transform.position.y,  goal.transform.position.z);

        Vector3 direction = target - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

        speed = Mathf.Clamp(speed + (accelerate * Time.deltaTime), minSpeed, maxSpeed);

        if (Vector3.Angle(goal.forward, this.transform.forward) > breakAngle && speed > 2)
        {
            speed = Mathf.Clamp(speed - (decelerate * Time.deltaTime), minSpeed, maxSpeed);
        }
        else
        {
            speed = Mathf.Clamp(speed + (accelerate * Time.deltaTime), minSpeed, maxSpeed);
        }
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }

}
