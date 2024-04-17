using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private float _rayDistance;

    public bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -(transform.up), _rayDistance, _groundLayerMask);
    }
}
