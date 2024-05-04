using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.PlayerRep.Helpers
{
    public class PlayerInput : MonoBehaviour
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string JumpAxisName = "Jump";
        private const string AttackAxisName = "Fire3";

        public float HorizontalAxis { get; private set; }
        public float VerticalAxis { get; private set; }
        public float AttackAxis { get; private set; }

        private void Update()
        {
            HorizontalAxis = Input.GetAxisRaw(HorizontalAxisName);
            VerticalAxis = Input.GetAxisRaw(JumpAxisName);
            AttackAxis = Input.GetAxisRaw(AttackAxisName);
        }
    }
}
