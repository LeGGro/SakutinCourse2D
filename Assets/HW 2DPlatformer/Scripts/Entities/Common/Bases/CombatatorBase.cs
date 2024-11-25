using Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.Common.Bases
{
    [RequireComponent(typeof(Indicator))]
    public abstract class CombatatorBase : MonoBehaviour
    {
        [SerializeField] private Collider2D _attackTrigger;
        [SerializeField] private float _attackForce;
        [SerializeField] private float _attackCooldown;
        [SerializeField] private float _hurtTriggerCooldown;

        private bool _isReadyAttack = true;
        private bool _isReadyHurt = true;
        protected Indicator Health;

        public bool IsHurted { get; protected set; } = false;

        protected virtual void Start()
        {
            Health = GetComponent<Indicator>();
        }

        protected virtual void Update()
        {
            if (IsHurted == true && _isReadyHurt == true)
            {
                IsHurted = false;
            }
        }

        public virtual void DealDamage(float damage)
        {
            Health.Substruct(damage);
            
            IsHurted = true;
            _isReadyHurt = false;

            StartCoroutine(Cooldown(_hurtTriggerCooldown, CooldownType.Hurt));
        }

        public virtual bool Attack()
        {
            if (_isReadyAttack)
            {
                _isReadyAttack = false;

                List<Collider2D> results = new();
                _attackTrigger.GetContacts(results);

                foreach (Collider2D collider in results)
                {
                    if (collider.TryGetComponent(out CombatatorBase controller))
                    {
                        controller.DealDamage(_attackForce);
                    }
                }

                StartCoroutine(Cooldown(_attackCooldown, CooldownType.Attack));

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