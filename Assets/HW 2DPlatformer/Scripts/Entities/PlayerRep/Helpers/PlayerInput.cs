using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.PlayerRep.Helpers
{
    public class PlayerInput : MonoBehaviour
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string JumpAxisName = "Jump";
        private const string MeleeAttackAxisName = "Fire3";

        public float HorizontalAxis  => Input.GetAxisRaw(HorizontalAxisName);
        public float VerticalAxis => Input.GetAxisRaw(JumpAxisName);
        public float MeleeAttackAxis => Input.GetAxisRaw(MeleeAttackAxisName);
    }
}
