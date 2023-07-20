using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealth
    {
        get => _maxHealth;
    }

    public int CurrentHealth
    {
        get => _currentHealth;
    }

    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;

    public void Initialize(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        _currentHealth = Mathf.Max(_currentHealth, 0);
    }

}