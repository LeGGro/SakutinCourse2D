using Assets.HW_2DPlatformer.Scripts.Entities.Common.Bases;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.PlayerRep.Helpers
{
    [RequireComponent(typeof(Player))]
    public class PlayerBasicCombatator : CombatatorBase
    {
        [SerializeField] private Collider2D _attackTrigger;
        [SerializeField] private float _attackForce;
        [SerializeField] private float _attackCooldown;

        private float _attackTime = 0;
        private Player _player;

        private void Start()
        {
            _player = GetComponent<Player>();
        }

        private void Update()
        {
            _attackTime += Time.deltaTime;
        }

        public override void GetDamage(float damage)
        {
            _player.DealDamage(damage);
        }

        public override bool Attack()
        {
            if (_attackTime >= _attackCooldown)
            {
                List<Collider2D> results = new List<Collider2D>();
                _attackTrigger.OverlapCollider(default, results);

                foreach (Collider2D collider in results)
                {
                    if (collider.TryGetComponent(out CombatatorBase controller))
                    {
                        controller.GetDamage(_attackForce);
                    }
                }

                _attackTime = 0;

                return true;
            }

            return false;
        }
    }
}