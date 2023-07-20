using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Drive : MonoBehaviour {

    [SerializeField] private Health health;
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    public GameObject explosion;

    void Start()
    {
        health = gameObject.GetComponent<Health>();
        health.Initialize(100);
    }
    void Update() {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (health.CurrentHealth <= 0)
        {
            Time.timeScale = 0;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        if (bullet != null )
        {
            health.TakeDamage(3);
        }
    }

}
