using Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers;
using System.Collections;
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
        [SerializeField] private float _hurtTriggerCooldown;

        private float _attackTime = 0;
        private bool _isReadyAttack = true;
        private float _hurtTriggerTime = 0;
        private bool _isReadyHurt = true;
        protected Health Health;

        public bool IsHurted { get; protected set; } = false;

        protected virtual void Start()
        {
            Health = GetComponent<Health>();
        }

        protected virtual void Update()
        {
            if (IsHurted == true && _isReadyHurt)
            {
                IsHurted = false;
            }
        }
        public virtual void DealDamage(float damage)
        {
            Health.DealDamage(damage);
            IsHurted = true;
            
            _ = StartCoroutine(Cooldown(_hurtTriggerCooldown, CooldownType.Hurt));
        }
        public virtual bool Attack()
        {
            if (_isReadyAttack)
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

                _ = StartCoroutine(Cooldown(_attackCooldown, CooldownType.Attack)); ;

                return true;
            }

            return false;
        }
        protected IEnumerator Cooldown(float cooldownTime, CooldownType type)
        {
            yield return new WaitForSeconds(cooldownTime);

            switch (type)
            {
                case CooldownType.Attack:
                    _isReadyAttack = true;
                    break;

                case CooldownType.Hurt:
                    _isReadyHurt = true;
                    break;
            }

            yield break;
        }
    }

    public enum CooldownType
    {
        Attack,
        Hurt,
    }
}