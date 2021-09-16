using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public int Health => _health;

    [SerializeField] private int _health;
    [HideInInspector] public UnityEvent OnHealthChanged;

    private int _maxHealth;

    private void Awake()
    {
        _maxHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        OnHealthChanged?.Invoke();
    }

    public void Heal(int health)
    {
        if (_health + health <= _maxHealth)
        {
            _health += health;
            OnHealthChanged?.Invoke();
        }
    }
}
