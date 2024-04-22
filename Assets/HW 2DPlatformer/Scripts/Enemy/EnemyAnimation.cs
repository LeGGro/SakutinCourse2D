using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    private int SpeedHorizontal = Animator.StringToHash(nameof(SpeedHorizontal));
    private int IsGrounded = Animator.StringToHash(nameof(IsGrounded));

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetupParams(float horizontalAxis, bool isGrounded)
    {
        _animator.SetFloat(SpeedHorizontal, Mathf.Abs(horizontalAxis));
        _animator.SetBool(IsGrounded, isGrounded);
    }
}
