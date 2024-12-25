using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.PlayerRep.Helpers
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        private int _speedHorizontal = Animator.StringToHash(nameof(_speedHorizontal));
        private int _isGrounded = Animator.StringToHash(nameof(_isGrounded));
        private int _speedVertical = Animator.StringToHash(nameof(_speedVertical));
        private int _isAttacking = Animator.StringToHash(nameof(_isAttacking));
        private int _isHurted = Animator.StringToHash(nameof(_isHurted));

        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void ControlAnimation(float horizontalAxis, float verticalAxis, bool isGrounded)
        {
            _animator.SetFloat(_speedHorizontal, Mathf.Abs(horizontalAxis));
            _animator.SetFloat(_speedVertical, Mathf.Abs(verticalAxis));
            _animator.SetBool(_isGrounded, isGrounded);
        }

        public void SetTrigger(TriggerType triggerType)
        {
            switch (triggerType)
            {
                case TriggerType.HurtTrigger:
                    _animator.SetTrigger(_isHurted);
                    break;

                case TriggerType.AttackTrigger:
                    _animator.SetTrigger(_isAttacking);
                    break;
            }
        }
    }

    public enum TriggerType
    {
        HurtTrigger,
        AttackTrigger,
    }
}