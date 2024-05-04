using Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers;
using Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Bases;
using Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Helpers;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep
{
    [RequireComponent(typeof(EnemyMoverBase), typeof(EnemyAnimation), typeof(EnemyBehaviorBase))]
    [RequireComponent(typeof(Rigidbody2D), typeof(DirectionFlipper), typeof(EnemyPlayerDetector))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private GroundChecker _groundChecker;
        [SerializeField] private EnemyBehaviorBase _defaultBehavior;
        [SerializeField] private EnemyBehaviorBase _playerDetectionBehavior;
        [SerializeField] private EnemyBehaviorBase _attackBehavior;
        [SerializeField] private Health _health;

        private EnemyMoverBase _movement;
        private DirectionFlipper _flipper;
        private EnemyAnimation _animator;
        private EnemyPlayerDetector _detector;

        private EnemyBehaviorBase _currentBehavior;

        public bool IsAttacking { get; set; }

        private void Start()
        {
            _movement = GetComponent<EnemyMoverBase>();
            _flipper = GetComponent<DirectionFlipper>();
            _animator = GetComponent<EnemyAnimation>();
            _detector = GetComponent<EnemyPlayerDetector>();
            _movement.Initialize(_moveSpeed, GetComponent<Rigidbody2D>());

            _currentBehavior = _defaultBehavior;
            _currentBehavior.Activate();
        }

        private void Update()
        {
            if (_detector.CanAttackPlayer())
            {
                if (_currentBehavior != _attackBehavior)
                {
                    _currentBehavior.Deactivate();
                    _currentBehavior = _attackBehavior;
                    _currentBehavior.Activate();
                }
            }
            else if (_detector.CanSeePlayer())
            {
                if (_currentBehavior != _playerDetectionBehavior)
                {
                    _currentBehavior.Deactivate();
                    _currentBehavior = _playerDetectionBehavior;
                    _currentBehavior.Activate();
                }
            }
            else
            {
                if (_currentBehavior != _defaultBehavior)
                {
                    _currentBehavior.Deactivate();
                    _currentBehavior = _defaultBehavior;
                    _currentBehavior.Activate();
                }
            }

            Vector2 moveDirection = _currentBehavior.MoveDirection;

            _movement.Move(moveDirection);
            _flipper.Flip(moveDirection.x);
            _animator.SetupParams(moveDirection.x, _groundChecker.IsGrounded());

            if (IsAttacking)
            {
                _animator.SetTrigger(TriggerType.AttackTrigger);
            }
        }

        internal void DealDamage(float damage)
        {
            _health.DealDamage(damage);
            _animator.SetTrigger(TriggerType.HurtTrigger);
        }
    }
}