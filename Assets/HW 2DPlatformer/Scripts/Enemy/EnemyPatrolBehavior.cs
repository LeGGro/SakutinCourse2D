using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolBehavior : EnemyBehaviorBase
{
    [SerializeField] private List<Transform> _pathPoints;
    [SerializeField] private float _closeRange;

    private int _currentTargetIndex;

    public override Vector2 MoveDirection => new Vector2((_pathPoints[_currentTargetIndex].position - transform.position).normalized.x, 0);

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
