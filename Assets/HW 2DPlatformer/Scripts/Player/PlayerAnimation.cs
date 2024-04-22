using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private int SpeedHorizontal = Animator.StringToHash(nameof(SpeedHorizontal));
    private int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
    private int SpeedVertical = Animator.StringToHash(nameof(SpeedVertical));

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ControlAnimation(float horizontalAxis, float verticalAxis, bool isGrounded)
    {
        _animator.SetFloat(SpeedHorizontal, Mathf.Abs(horizontalAxis));
        _animator.SetFloat(SpeedVertical, Mathf.Abs(verticalAxis));
        _animator.SetBool(IsGrounded, isGrounded);
    }
}
