using UnityEngine;

[RequireComponent(typeof(EnemyMovementBase), typeof(EnemyAnimation), typeof(EnemyBehaviorBase))]
[RequireComponent(typeof(Rigidbody2D), typeof(DirectionFlipper))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GroundChecker _groundChecker;

    private EnemyMovementBase _movement;
    private DirectionFlipper _flipper;
    private EnemyAnimation _animator;
    private EnemyBehaviorBase _behavior;

    private void Start()
    {
        _movement = GetComponent<EnemyMovementBase>();
        _behavior = GetComponent<EnemyBehaviorBase>();
        _flipper = GetComponent<DirectionFlipper>();
        _animator = GetComponent<EnemyAnimation>();
        _movement.Initialize(_moveSpeed, GetComponent<Rigidbody2D>());
        _behavior.Activate();
    }

    private void FixedUpdate()
    {
        Vector2 moveDirection = _behavior.MoveDirection;

        _movement.Move(moveDirection);
        _flipper.Flip(moveDirection.x);
        _animator.ControlAnimation(moveDirection.x, _groundChecker.IsGrounded());
    }
}
