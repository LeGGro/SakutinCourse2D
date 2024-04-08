using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHitpointAmount;
    [SerializeField] private float _minHealth = 0;

    public bool IsAlive { get { return _currentHitpointAmount > _minHealth; } }

    public void DealDamage(float damage)
    {
        _currentHitpointAmount = Mathf.Clamp(_currentHitpointAmount - damage, _minHealth, _currentHitpointAmount);
    }

    public void DealHeal(float heal)
    {
        _currentHitpointAmount = Mathf.Clamp(_currentHitpointAmount - heal, _currentHitpointAmount, _maxHealth);
    }
}
