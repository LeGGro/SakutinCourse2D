using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Helpers
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimation : MonoBehaviour
    {
        private int SpeedHorizontal = Animator.StringToHash(nameof(SpeedHorizontal));
        private int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
        private int AttackTrigger = Animator.StringToHash(nameof(AttackTrigger));
        private int HurtTrigger = Animator.StringToHash(nameof(HurtTrigger));

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

        public void SetTrigger(TriggerType triggerType)
        {
            switch (triggerType)
            {
                case TriggerType.AttackTrigger:
                    _animator.SetTrigger(AttackTrigger);
                    break;
                
                case TriggerType.HurtTrigger:
                    _animator.SetTrigger(HurtTrigger);
                    break;
            }
        }
    }

    public enum TriggerType
    {
        HurtTrigger,
        AttackTrigger
    }
}
