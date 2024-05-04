using Assets.HW_2DPlatformer.Scripts.Entities.Common.Bases;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Helpers
{
    public class EnemyBasicCombatator : CombatatorBase
    {
        [SerializeField] private Collider2D _attackTrigger;
        [SerializeField] private float _attackForce;
        [SerializeField] private float _attackCooldown;

        private float _attackTimer = 0;
        private Enemy _enemy;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
        }
        private void Update()
        {
            _attackTimer += Time.deltaTime;
        }

        public override bool Attack()
        {
            if (_attackTimer >= _attackCooldown)
            {
                _attackTimer = 0;

                List<Collider2D> results = new List<Collider2D>();
                _attackTrigger.OverlapCollider(default, results);

                foreach (Collider2D collider in results)
                {
                    if (collider.TryGetComponent(out CombatatorBase controller))
                    {
                        controller.GetDamage(_attackForce);
                    }
                }

                return true;
            }

            return false;
        }

        public override void GetDamage(float damage)
        {
            _enemy.DealDamage(damage);
        }
    }
}