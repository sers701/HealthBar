using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private int _framesToChangeBar;
    [SerializeField] private Player _player;

    private Slider _slider;
    private Coroutine _coroutine;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        SetMaxHealth(_player.Health);
    }

    private void OnEnable()
    {
        _player.OnHealthChanged.AddListener(StartSetHealth);
    }

    private void OnDisable()
    {
        _player.OnHealthChanged.RemoveListener(StartSetHealth);
    }

    private void SetMaxHealth(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }

    private void StartSetHealth()
    {
        int currentHealth = _player.Health;
        if (_coroutine != null)
        {
             StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(SetHealth(currentHealth));
    }

    private IEnumerator SetHealth(int currentHealth)
    {
        float difference = _slider.value - currentHealth;
        float changePerFrame =  (difference) / _framesToChangeBar;
        for (int i = 0; i < _framesToChangeBar; i++)
        {
            _slider.value = _slider.value - changePerFrame;
            yield return null;
        }
    }
}
