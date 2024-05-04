using Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Bases;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Helpers
{
    public class EnemyBasicMover : EnemyMoverBase
    {
        private float _speed;
        private Rigidbody2D _rigidbody;

        public override void Initialize(float speed, Rigidbody2D rigidbody)
        {
            _speed = speed;
            _rigidbody = rigidbody;
        }

        public override void Move(Vector2 direction)
        {
            _rigidbody.velocity = new Vector2(direction.x * _speed, _rigidbody.velocity.y);
        }
    }
}