using Assets.HW_2DPlatformer.Scripts;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerBasicMovement), typeof(PlayerInput), typeof(PlayerAnimation))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpCooldown;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private List<ScriptableObject> _inventory;

    private PlayerInput _input;
    private PlayerMovementBase _movement;
    private PlayerAnimation _animator;

    private float _jumpTimer = 0;

    private void Start()
    {
        if (_groundChecker == null)
        {
            Debug.LogError("_groundChecker is null");  
        }

        _movement = GetComponent<PlayerMovementBase>(); 
        _input = GetComponent<PlayerInput>();
        _animator = GetComponent<PlayerAnimation>();
    }

    public void FixedUpdate()
    {
        if (_input.HorizontalAxis != 0)
        {
            _movement.Move(_input.HorizontalAxis, _speed);
        }
        if (_input.VerticalAxis != 0)
        {
            if (_groundChecker.IsGrounded() == true && _jumpCooldown >= _jumpTimer)
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
