using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private int _framesToChangeBar;

    private Slider _slider;
    private Coroutine _coroutine;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }

    public void StartSetHealth(int currentHealth)
    {
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
