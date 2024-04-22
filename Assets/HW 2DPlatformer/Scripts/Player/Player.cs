using Assets.HW_2DPlatformer.Scripts;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(DirectionFlipper))]
[RequireComponent(typeof(PlayerMovementBase), typeof(PlayerInput), typeof(PlayerAnimation))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpCooldown;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private List<ScriptableObject> _inventory;
    [SerializeField] private PlayerMovementBase _movement;

    private PlayerInput _input;
    private PlayerAnimation _animator;

    private float _jumpTimer = 0;

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

        _animator.ControlAnimation(_input.HorizontalAxis, _input.VerticalAxis, _groundChecker.IsGrounded());
    }

    public void CollectItem(ScriptableObject item)
    {
        _inventory.Add(item);
    }
}
