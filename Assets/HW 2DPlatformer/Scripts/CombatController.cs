using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(HealthController))]
public class CombatController : MonoBehaviour
{
    private const string AttackAxisName = "Fire3";

    [SerializeField] private Collider2D _attackTrigger;
    [SerializeField] private float _attackForce;
    [SerializeField] private float _attackCooldown;

    private float _attackTime = 0;
    private HealthController _healthController;

    private void Start()
    {
        _healthController = GetComponent<HealthController>();
    }

    private void Update()
    {
        float fireAxis = Input.GetAxisRaw(AttackAxisName);
        _attackTime += Time.deltaTime;

        if (fireAxis != 0 && _attackCooldown > _attackTime)
        {
            Attack();
            _attackTime = 0;
        }
    }

    public void GetDamage(float damage)
    {
        _healthController.DealDamage(damage);
    }

    private void Attack()
    {
        List<Collider2D> results = new List<Collider2D>();
        _attackTrigger.OverlapCollider(default, results);

        foreach (Collider2D collider in results)
        {
            if (collider.TryGetComponent(out CombatController controller))
            {
                controller.GetDamage(_attackForce);
            }
        }
    }
}
