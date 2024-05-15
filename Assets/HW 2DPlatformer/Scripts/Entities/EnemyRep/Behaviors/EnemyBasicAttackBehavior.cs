using Assets.HW_2DPlatformer.Scripts.Entities.Common.Bases;
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
        public override bool IsAttacking { get; protected set; }

        protected override IEnumerator Acting()
        {
            while (true)
            {
                yield return new WaitForFixedUpdate();

                IsAttacking = _basicCombatator.Attack();
            }
        }
    }
}
