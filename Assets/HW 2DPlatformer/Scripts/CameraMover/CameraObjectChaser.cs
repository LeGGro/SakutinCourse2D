using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.CameraMover
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CameraObjectChaser : MonoBehaviour
    {
        [SerializeField] private Transform _chaseObject;
        [SerializeField] private float _freedomSpaceRadius;
        [SerializeField] private float _moveSpeed;

        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (ShouldChase())
            {
                Move((_chaseObject.transform.position - transform.position).normalized);
            }
        }

        private bool ShouldChase()
        {
            return Mathf.Abs((_chaseObject.transform.position - transform.position).magnitude) > _freedomSpaceRadius;
        }

        private void Move(Vector2 moveDirection)
        {
            _rigidbody.velocity = moveDirection * _moveSpeed;
        }
    }
}