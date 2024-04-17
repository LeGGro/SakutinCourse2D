using Assets.HW_2DPlatformer.Scripts;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBasicMovement : MonoBehaviour, PlayerMovementBase
{
    private Rigidbody2D _rigidbody;
    private float _jumpTimer = 0;
    private float _lastMoveDirection;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _jumpTimer = Time.deltaTime;
    }

    public void Move(float HorizontalAxis, float Speed)
    {
        _rigidbody.velocity = new Vector2(Speed * HorizontalAxis, _rigidbody.velocity.y);

        if (math.sign( _lastMoveDirection) != math.sign( HorizontalAxis))
        {
            Flip(HorizontalAxis);
        }
    }

    public void Jump(float JumpForce)
    {
        _rigidbody.AddForce(transform.up.normalized * JumpForce, ForceMode2D.Impulse);
        _jumpTimer = 0;
    }

    private void Flip(float horizontalAxis)
    {
        if (horizontalAxis < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
