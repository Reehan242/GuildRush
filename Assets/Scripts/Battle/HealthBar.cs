using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite;
    [SerializeField] private float _reduceSpeed = 2f;
    private float _target = 1;

    public void UpdateHealthBar(float maxHealth, float CurrentHealth)
    {
        _target = CurrentHealth/maxHealth;
    }

    void Update()
    {
        _healthbarSprite.fillAmount = Mathf.MoveTowards(_healthbarSprite.fillAmount, _target, _reduceSpeed * Time.deltaTime);
    }
}
