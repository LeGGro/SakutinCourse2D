using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AnimationController))]

public class MovementController : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string JumpAxisName = "Jump";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpCooldown;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private Collider2D _groundTrigger;

    private Rigidbody2D _rigidbody;
    private float _jumpTimer = 0;
    private AnimationController _animationController;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animationController = GetComponent<AnimationController>();
    }

    private void Update()
    {
        float horizontalAxis = Input.GetAxisRaw(HorizontalAxisName);
        float verticalAxis = Input.GetAxisRaw(JumpAxisName);
        bool isGrounded = IsGrounded();
        _animationController.HorizontalSpeed = horizontalAxis;
        _animationController.VerticalSpeed = verticalAxis;
        _animationController.IsGrounded = isGrounded;
        _jumpTimer += Time.deltaTime;

        if (horizontalAxis != 0)
        {
            Move(horizontalAxis);
        }

        if (verticalAxis != 0 && _jumpTimer >= _jumpCooldown)
        {
            if (isGrounded)
            {
                Jump();
            }
        }
    }

    private void Move(float horizontalAxis)
    {
        _rigidbody.velocity = new Vector2(_speed * horizontalAxis, _rigidbody.velocity.y);
        Flip(horizontalAxis);
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

    private void Jump()
    {
        _rigidbody.AddForce(transform.up.normalized * _jumpForce, ForceMode2D.Force);
        _jumpTimer = 0;
    }

    private bool IsGrounded()
    {
        return _groundTrigger.IsTouchingLayers(_groundLayerMask.value);
    }
}
