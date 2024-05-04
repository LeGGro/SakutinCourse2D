using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.PlayerRep.Helpers
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        private int SpeedHorizontal = Animator.StringToHash(nameof(SpeedHorizontal));
        private int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
        private int SpeedVertical = Animator.StringToHash(nameof(SpeedVertical));
        private int IsAttacking = Animator.StringToHash(nameof(IsAttacking));
        private int IsHurted = Animator.StringToHash(nameof(IsHurted));

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

        public void SetTrigger(TriggerType triggerType)
        {
            switch (triggerType)
            {
                case TriggerType.HurtTrigger:
                    _animator.SetTrigger(IsHurted);
                    break;

                case TriggerType.AttackTrigger:
                    _animator.SetTrigger(IsAttacking);
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