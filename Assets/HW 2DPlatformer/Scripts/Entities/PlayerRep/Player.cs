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
        [SerializeField] private AbilitySystem _abilities;
        [SerializeField] private PlayerMoverBase _movement;

        private PlayerInput _input;
        private PlayerAnimation _animator;

        private void Start()
        {
            _input = GetComponent<PlayerInput>();
            _animator = GetComponent<PlayerAnimation>();
            _movement.Initialize(GetComponent<Rigidbody2D>(), GetComponent<DirectionFlipper>());
            _abilities.Initialize(_health);
        }

        public void FixedUpdate()
        {
            float horizontalAxis = 0;

            if (_input.FirstAbilityAxis != 0)
            {
                _abilities.Activate(AbilityBindNumber.First);
            }
            else if (_input.SecondAbilityAxis != 0)
            {
                _abilities.Activate(AbilityBindNumber.Second);
            }
            else
            {
                if (_input.MeleeAttackAxis != 0 && _groundChecker.IsGrounded())
                {
                    if (_combatator.Attack() == true)
                    {
                        _animator.SetTrigger(TriggerType.AttackTrigger);
                    }
                }
                else
                {
                    if (_combatator.IsHurted)
                    {
                        _animator.SetTrigger(TriggerType.HurtTrigger);
                    }
                    else
                    {
                        horizontalAxis = _input.HorizontalAxis;

                        if (horizontalAxis != 0)
                        {
                            _movement.Move(horizontalAxis);
                        }
                        if (_input.VerticalAxis != 0)
                        {
                            if (_groundChecker.IsGrounded() == true)
                            {
                                _movement.Jump();
                            }
                        }
                    }
                }
            }

            _animator.ControlAnimation(horizontalAxis, _input.VerticalAxis, _groundChecker.IsGrounded());
        }
    }
}
