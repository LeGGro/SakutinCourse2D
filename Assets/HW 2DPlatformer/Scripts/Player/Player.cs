using Assets.HW_2DPlatformer.Scripts;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(DirectionFlipper))]
[RequireComponent(typeof(PlayerMoverBase), typeof(PlayerInput), typeof(PlayerAnimation))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpCooldown;
    [SerializeField] private GroundChecker _groundChecker;
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
        if (_input.HorizontalAxis != 0)
        {
            _movement.Move(_input.HorizontalAxis, _speed);
        }
        if (_input.VerticalAxis != 0)
        {
            if (_groundChecker.IsGrounded() == true)
            {
                _movement.Jump(_jumpForce);
            }
        }

        _animator.SetupParams(_input.HorizontalAxis, _input.VerticalAxis, _groundChecker.IsGrounded());
    }
}
