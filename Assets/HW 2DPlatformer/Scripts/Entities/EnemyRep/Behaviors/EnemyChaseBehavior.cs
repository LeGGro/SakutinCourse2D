using Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Bases;
using Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Helpers;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Behaviors
{
    [RequireComponent(typeof(Enemy), typeof(EnemyPlayerDetector))]
    public class EnemyChaseBehavior : EnemyBehaviorBase
    {
        private EnemyPlayerDetector _playerDetector;

        public override Vector2 MoveDirection => new Vector2((_playerDetector.Player.transform.position - transform.position).normalized.x * Convert.ToInt32(!_freezeX),
            (_playerDetector.Player.transform.position - transform.position).normalized.y * Convert.ToInt32(!_freezeY));

        private void Start()
        {
            _playerDetector = GetComponent<EnemyPlayerDetector>();
        }

        protected override IEnumerator Acting()
        {
            yield return null;
        }
    }
}
