using System.Collections;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private float _rayDistance;
        [SerializeField] private float _checkInterval;
        private WaitForSeconds _checkTime;

        public bool IsGrounded { get; private set; }

        public void Initialize()
        {
            IsGrounded = false;
            _checkTime = new WaitForSeconds(_checkInterval);
            StartCoroutine(UpdatingProperty());
        }

        private IEnumerator UpdatingProperty()
        {
            while (enabled == true)
            {
                yield return _checkTime;
                IsGrounded = Physics2D.Raycast(transform.position, -transform.up, _rayDistance, _groundLayerMask);
            }
        }
    }
}