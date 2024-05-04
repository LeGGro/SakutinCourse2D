using Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Bases;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Behaviors
{
    public class EnemyPatrolBehavior : EnemyBehaviorBase
    {
        [SerializeField] private List<Transform> _pathPoints;
        [SerializeField] private float _closeRange;

        private int _currentTargetIndex;

        public override Vector2 MoveDirection => (_pathPoints[_currentTargetIndex].position - transform.position).normalized;

        protected override IEnumerator Acting()
        {
            while (true)
            {
                if (IsCloseUp())
                {
                    ChangePathPoint();
                }

                yield return null;
            }
        }

        private bool IsCloseUp()
        {
            return (transform.position - _pathPoints[_currentTargetIndex].position).magnitude <= _closeRange;
        }

        private void ChangePathPoint()
        {
            _currentTargetIndex = ++_currentTargetIndex % _pathPoints.Count;
        }
    }
}
