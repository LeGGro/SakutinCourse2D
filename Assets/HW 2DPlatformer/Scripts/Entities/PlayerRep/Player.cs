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
        [SerializeField] private GroundChecker _groundChecker;
        [SerializeField] private CombatatorBase _combatator;
        [SerializeField] private Indicator _health;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private PlayerMoverBase _movement;

        private PlayerInput _input;
        private PlayerAnimation _animator;

        private void Start()
        {
            _input = GetComponent<PlayerInput>();
            _animator = GetComponent<PlayerAnimation>();
            _movement.Initialize(GetComponent<Rigidbody2D>(), GetComponent<DirectionFlipper>());
            _groundChecker.Initialize();
            _health.Initialize();
        }

        public void Update()
        {
            bool groundCheck = _groundChecker.IsGrounded;
            float horizontalAxis = _input.HorizontalAxis;
            float verticalAxis = _input.VerticalAxis;
            
            if (_input.MeleeAttackAxis != 0 && groundCheck && _combatator.Attack() == true)
            {
                _animator.SetTrigger(TriggerType.AttackTrigger);
            }
            else if (_combatator.IsHurted)
            {
                _animator.SetTrigger(TriggerType.HurtTrigger);
            }
            else if (horizontalAxis != 0)
            {
                _movement.Move(horizontalAxis);
            }

            if (verticalAxis != 0 && groundCheck == true)
            {
                _movement.Jump();
            }

            _animator.ControlAnimation(horizontalAxis, verticalAxis, groundCheck);
        }
    }
}

