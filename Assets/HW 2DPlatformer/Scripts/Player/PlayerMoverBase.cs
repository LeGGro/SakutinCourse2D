using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts
{
    public abstract class PlayerMoverBase: MonoBehaviour
    {
        public abstract void Move(float HorizontalAxis, float Speed);
        public abstract void Jump(float jumpForce);
        public abstract void Initialize(Rigidbody2D rigidbody, float jumpCooldown, DirectionFlipper flipper);
    }
}
