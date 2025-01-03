using Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Bases;
using Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Helpers;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Behaviors
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyChaseBehavior : EnemyBehaviorBase
    {
        [SerializeField] private EnemyPlayerDetector _playerDetector;

        public override Vector2 MoveDirection => new Vector2((_playerDetector.Player.transform.position - transform.position).normalized.x * Convert.ToInt32(!FreezeX),
            (_playerDetector.Player.transform.position - transform.position).normalized.y * Convert.ToInt32(!FreezeY));

        public override bool IsAttacking { get; protected set; } = false;

        protected override IEnumerator Acting()
        {
            yield return null;
        }
    }
}
