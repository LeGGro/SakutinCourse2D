using UnityEngine;

public class EnemyMovementBasic : EnemyMovementBase
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
