using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject player;
    private Health health;
    public GameObject button;

    void Start()
    {
        health = player.GetComponent<Health>();
        button.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (health != null && health.CurrentHealth <= 0)
        {
            button.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
