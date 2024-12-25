using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Helpers
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimation : MonoBehaviour
    {
        private int _speedHorizontal = Animator.StringToHash(nameof(_speedHorizontal));
        private int _isGrounded = Animator.StringToHash(nameof(_isGrounded));
        private int _attackTrigger = Animator.StringToHash(nameof(_attackTrigger));
        private int _hurtTrigger = Animator.StringToHash(nameof(_hurtTrigger));

        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetupParams(float horizontalAxis, bool isGrounded)
        {
            _animator.SetFloat(_speedHorizontal, Mathf.Abs(horizontalAxis));
            _animator.SetBool(_isGrounded, isGrounded);
        }

        public void SetTrigger(TriggerType triggerType)
        {
            switch (triggerType)
            {
                case TriggerType.AttackTrigger:
                    _animator.SetTrigger(_attackTrigger);
                    break;
                
                case TriggerType.HurtTrigger:
                    _animator.SetTrigger(_hurtTrigger);
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
