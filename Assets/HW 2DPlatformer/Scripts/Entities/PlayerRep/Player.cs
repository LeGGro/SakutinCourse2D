using Assets.HW_2DPlatformer.Scripts.Entities.Common.Bases;
using Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers;
using Assets.HW_2DPlatformer.Scripts.Entities.PlayerRep.Bases;
using Assets.HW_2DPlatformer.Scripts.Entities.PlayerRep.Helpers;
using Assets.HW_2DPlatformer.Scripts.InventorySystem;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.PlayerRep
{
    [RequireComponent(typeof(Rigidbody2D), typeof(DirectionFlipper))]
    [RequireComponent(typeof(PlayerMoverBase), typeof(PlayerInput), typeof(PlayerAnimation))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _jumpCooldown;

        [SerializeField] private GroundChecker _groundChecker;
        [SerializeField] private CombatatorBase _combatator;
        [SerializeField] private Health _health;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private PlayerMoverBase _movement;

        private PlayerInput _input;
        private PlayerAnimation _animator;

        private void Start()
        {
            _input = GetComponent<PlayerInput>();
            _animator = GetComponent<PlayerAnimation>();
            _movement.Initialize(GetComponent<Rigidbody2D>(), _jumpCooldown, GetComponent<DirectionFlipper>());
        }

        public void FixedUpdate()
        {
            float horizontalAxis = 0;

            if (_input.AttackAxis != 0 && _groundChecker.IsGrounded())
            {
                if (_combatator.Attack() == true) 
                {
                    _animator.SetTrigger(TriggerType.AttackTrigger);
                }
            }
            else
            {
                horizontalAxis = _input.HorizontalAxis;

                if (horizontalAxis != 0)
                {
                    _movement.Move(horizontalAxis, _speed);
                }
                if (_input.VerticalAxis != 0)
                {
                    if (_groundChecker.IsGrounded() == true)
                    {
                        _movement.Jump(_jumpForce);
                    }
                }
            }

            _animator.ControlAnimation(horizontalAxis, _input.VerticalAxis, _groundChecker.IsGrounded());
        }

        public void DealDamage(float damage)
        {
            _health.DealDamage(damage);
            _animator.SetTrigger(TriggerType.HurtTrigger);
        }
    }
}
