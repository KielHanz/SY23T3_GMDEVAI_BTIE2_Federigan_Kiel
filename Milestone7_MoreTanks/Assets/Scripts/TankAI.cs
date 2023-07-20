using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    Animator anim;

    public GameObject player;

    public GameObject bullet;
    public GameObject turret;
    public GameObject explosion;

    [SerializeField] private Health health;

    public GameObject GetPlayer()
    {
        return player;
    }

    void Start()
    {
        anim = this.GetComponent<Animator>();
        health = gameObject.GetComponent<Health>();
        health.Initialize(100);
        anim.SetFloat("hp", health.CurrentHealth);
    }

    void Update()
    {
        anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));

        if (health.CurrentHealth <= 0)
        {
            GameObject e = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(e, 1.5f);
            Destroy(this.gameObject);
        }
    }

    void Fire()
    {
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            health.TakeDamage(5);
            anim.SetFloat("hp", health.CurrentHealth);
        }
    }
}
