using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject turret;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
            b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
        }
    }
}
