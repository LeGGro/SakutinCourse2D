using Assets.HW_2DPlatformer.Scripts.Entities.PlayerRep;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Helpers
{
    public class EnemyPlayerDetector : MonoBehaviour
    {
        [SerializeField] private float _detectionSphereRadius;
        [SerializeField] private Collider2D _attackCollider;
        [SerializeField] private LayerMask _detectionLayerMask;
        
        private Collider2D _detectionCollider;

        public Player Player { get; private set; }

        private bool CheckPlayerPresense()
        {
            if (_detectionCollider == null)
            {
                _detectionCollider = CreateDetectionCollider();
            }

            List<Collider2D> collisions = new List<Collider2D>();
            _detectionCollider.GetContacts(collisions);

            foreach (var collision in collisions)
            {
                if (collision.gameObject.TryGetComponent(out Player player))
                {
                    Player = player;
                    return true;
                }
            }

            return false;
        }

        private Collider2D CreateDetectionCollider()
        {
            CircleCollider2D coll = this.gameObject.AddComponent<CircleCollider2D>();
            coll.radius = _detectionSphereRadius;
            coll.isTrigger = true;

            return coll;
        }
        
        public bool CanSeePlayer()
        {
            if (CheckPlayerPresense() == false)
            {
                return false;
            }
            else
            {
                RaycastHit2D raycast = Physics2D.Raycast(transform.position, (Player.gameObject.transform.position - transform.position), _detectionSphereRadius, _detectionLayerMask.value);

                if (raycast)
                {
                    if (raycast.transform.gameObject.TryGetComponent(out Player _))
                        return true;
                }

                return false;
            }
        }

        public bool CanAttackPlayer()
        {
            if (CanSeePlayer() == false)
            {
                return false;
            }
            else
            {
                List<Collider2D> collisions = new List<Collider2D>();
                _attackCollider.GetContacts(collisions);

                foreach (var collision in collisions)
                {
                    if (collision.gameObject.TryGetComponent(out Player _))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
