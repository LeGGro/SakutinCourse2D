namespace Assets.HW_2DPlatformer.Scripts
{
    public interface PlayerMovementBase
    {
        public abstract void Move(float HorizontalAxis, float Speed);
        public abstract void Jump(float jumpForce);
    }
}
