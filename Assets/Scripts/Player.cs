using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public int Health => _health;

    [SerializeField] private int _health;
    [SerializeField] private UnityEvent _onHealthChanged;

    private int _maxHealth;

    private void Awake()
    {
        _maxHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _onHealthChanged?.Invoke();
    }

    public void Heal(int health)
    {
        if (_health + health <= _maxHealth)
        {
            _health += health;
            _onHealthChanged.Invoke();
        }
    }
}
