using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public class EnemyPatrolMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> _pathPoints;
    [SerializeField] private float _closeRange;
    [SerializeField] private float _speed;

    private int _currentTargetIndex;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(PathMoving());
    }

    private IEnumerator PathMoving()
    {
        while (true)
        {
            if (IsCloseUp())
            {
                ChangePathPoint();
            }

            _rigidbody.velocity = new Vector2((_pathPoints[_currentTargetIndex].position - transform.position).normalized.x * _speed, _rigidbody.velocity.y );

            if ((_pathPoints[_currentTargetIndex].position - transform.position).normalized.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            yield return null;
        }
    }

    private bool IsCloseUp()
    {
        if ((transform.position - _pathPoints[_currentTargetIndex].position).magnitude <= _closeRange)
        {
            return true;
        }

        return false;
    }

    private void ChangePathPoint()
    {
        _currentTargetIndex = (++_currentTargetIndex) % _pathPoints.Count;
    }
}
