using Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers;
using Assets.HW_2DPlatformer.Scripts.Entities.PlayerRep.Bases;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.PlayerRep.Helpers
{
    public sealed class PlayerBasicMover : PlayerMoverBase
    {
        private Rigidbody2D _rigidbody;
        private float _jumpTimer = 0;
        private float _jumpCooldown = 0;
        private DirectionFlipper _flipper;

        public override void Initialize(Rigidbody2D rigidbody, float jumpCooldown, DirectionFlipper flipper)
        {
            _rigidbody = rigidbody;
            _jumpCooldown = jumpCooldown;
            _flipper = flipper;
        }

        private void FixedUpdate()
        {
            _jumpTimer += Time.fixedDeltaTime;
        }

        public override void Move(float HorizontalAxis, float Speed)
        {
            _rigidbody.velocity = new Vector2(Speed * HorizontalAxis, _rigidbody.velocity.y);
            _flipper.Flip(HorizontalAxis);
        }

        public override void Jump(float JumpForce)
        {
            if (_jumpCooldown <= _jumpTimer)
            {
                _rigidbody.AddForce(transform.up.normalized * JumpForce, ForceMode2D.Impulse);
                _jumpTimer = 0;
            }
        }
    }
}
