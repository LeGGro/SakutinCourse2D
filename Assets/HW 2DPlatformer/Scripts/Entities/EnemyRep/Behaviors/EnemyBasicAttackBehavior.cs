using Assets.HW_2DPlatformer.Scripts.Entities.Common.Bases;
using Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep;
using Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Bases;
using System.Collections;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Behaviors
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyBasicAttackBehavior : EnemyBehaviorBase
    {
        [SerializeField] private CombatatorBase _basicCombatator;

        public override Vector2 MoveDirection => Vector2.zero;

        private Enemy _enemy;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
        }

        protected override IEnumerator Acting()
        {
            while (true)
            {
                yield return new WaitForFixedUpdate();

                _enemy.IsAttacking = _basicCombatator.Attack();

            }
        }
    }
}
