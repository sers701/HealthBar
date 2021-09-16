using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private HealthBar _healthBar;

    private int _maxHealth;

    private void Awake()
    {
        _healthBar.SetMaxHealth(_health);
        _maxHealth = _health;
    }

    public void TakeDamage(int damage)
    {
            _health -= damage;
            _healthBar.StartSetHealth(_health);
    }

    public void Heal(int health)
    {
        if (_health + health <= _maxHealth)
        {
            _health += health;
            _healthBar.StartSetHealth(_health);
        }
    }
}
