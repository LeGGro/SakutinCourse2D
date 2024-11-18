using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.PlayerRep.Helpers
{
    public class PlayerInput : MonoBehaviour
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string JumpAxisName = "Jump";
        private const string MeleeAttackAxisName = "Fire3";
        private const string FirstAbilityAxisName = "Fire1";
        private const string SecondAbilityAxisName = "Fire2";

        public float HorizontalAxis { get; private set; }
        public float VerticalAxis { get; private set; }
        public float MeleeAttackAxis { get; private set; }
        public float FirstAbilityAxis { get; private set; }
        public float SecondAbilityAxis { get; private set; }

        private void Update()
        {
            HorizontalAxis = Input.GetAxisRaw(HorizontalAxisName);
            VerticalAxis = Input.GetAxisRaw(JumpAxisName);
            MeleeAttackAxis = Input.GetAxisRaw(MeleeAttackAxisName);
            FirstAbilityAxis = Input.GetAxisRaw(FirstAbilityAxisName);
            SecondAbilityAxis = Input.GetAxisRaw(SecondAbilityAxisName);
        }
    }
}
