using Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers;
using Assets.HW_2DPlatformer.Scripts.Entities.PlayerRep.Bases;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.PlayerRep.Helpers
{
    public sealed class PlayerBasicMover : PlayerMoverBase
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _jumpCooldown;

        private Rigidbody2D _rigidbody;
        private float _jumpTimer = 0;
        private DirectionFlipper _flipper;

        public override void Initialize(Rigidbody2D rigidbody, DirectionFlipper flipper)
        {
            _rigidbody = rigidbody;
            _flipper = flipper;
        }

        private void FixedUpdate()
        {
            _jumpTimer += Time.fixedDeltaTime;
        }

        public override void Move(float HorizontalAxis)
        {
            _rigidbody.velocity = new Vector2(_speed * HorizontalAxis, _rigidbody.velocity.y);
            _flipper.Flip(HorizontalAxis);
        }

        public override void Jump()
        {
            if (_jumpCooldown <= _jumpTimer)
            {
                _rigidbody.AddForce(transform.up.normalized * _jumpForce, ForceMode2D.Impulse);
                _jumpTimer = 0;
            }
        }
    }
}
