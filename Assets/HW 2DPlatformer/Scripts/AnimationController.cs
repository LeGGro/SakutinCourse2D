using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimationController : MonoBehaviour
{
    private readonly int Animation_SpeedHorizontal = Animator.StringToHash(nameof(Animation_SpeedHorizontal));
    private readonly int Animation_IsGrounded = Animator.StringToHash(nameof(Animation_IsGrounded));
    private readonly int Animation_SpeedVertical = Animator.StringToHash(nameof(Animation_SpeedVertical));

    private Animator _animator;

    public float HorizontalSpeed 
    { 
        set 
        {
            _animator.SetFloat(Animation_SpeedHorizontal, Mathf.Abs(value));
        } 
    }
    
    public float VerticalSpeed 
    { 
        set 
        {
            _animator.SetFloat(Animation_SpeedVertical, Mathf.Abs(value));
        } 
    }

    public bool IsGrounded
    {
        set
        {
            _animator.SetBool(Animation_IsGrounded, value);
        }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
