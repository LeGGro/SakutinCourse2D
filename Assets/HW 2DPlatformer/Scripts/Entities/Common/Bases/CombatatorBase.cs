using Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.Common.Bases
{
    [RequireComponent(typeof(Health))]
    public abstract class CombatatorBase : MonoBehaviour
    {
        [SerializeField] private Collider2D _attackTrigger;
        [SerializeField] private float _attackForce;
        [SerializeField] private float _attackCooldown;
        [SerializeField] private float _hurtCooldown;

        private float _attackTime = 0;
        private float _hurtTime = 0;
        protected Health Health;

        public bool IsHurted { get; protected set; } = false;

        protected virtual void Start()
        {
            Health = GetComponent<Health>();
        }

        protected virtual void Update()
        {
            _attackTime += Time.deltaTime;
            _hurtTime += Time.deltaTime;

            if (_hurtTime >= _hurtCooldown && IsHurted == true)
            {
                IsHurted = false;
            }
        }

        public virtual void DealDamage(float damage)
        {
            if (IsHurted == false)
            {
                Health.DealDamage(damage);
                IsHurted = true;
                _hurtTime = 0;
            }
        }
        public virtual bool Attack()
        {
            if (_attackTime >= _attackCooldown)
            {
                List<Collider2D> results = new List<Collider2D>();
                _attackTrigger.OverlapCollider(default, results);

                foreach (Collider2D collider in results)
                {
                    if (collider.TryGetComponent(out CombatatorBase controller))
                    {
                        controller.DealDamage(_attackForce);
                    }
                }

                _attackTime = 0;

                return true;
            }

            return false;
        }
    }
}