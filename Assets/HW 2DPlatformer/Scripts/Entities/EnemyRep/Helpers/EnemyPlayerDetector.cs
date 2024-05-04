using Assets.HW_2DPlatformer.Scripts.Entities.PlayerRep;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Helpers
{
    public class EnemyPlayerDetector : MonoBehaviour
    {
        [SerializeField] private float _detectionSphereRadius;
        [SerializeField] private Collider2D _attackCollider;

        public Player Player { get; private set; }

        private bool CheckPlayerPresense()
        {
            List<Collider2D> collisions = new List<Collider2D>();
            Physics2D.OverlapCircle(transform.position, _detectionSphereRadius, new ContactFilter2D(), collisions);

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

        public bool CanSeePlayer()
        {
            if (CheckPlayerPresense() == false)
            {
                return false;
            }
            else
            {
                RaycastHit2D raycast = Physics2D.Raycast(transform.position, (Player.gameObject.transform.position - transform.position), _detectionSphereRadius);

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
                Physics2D.OverlapCollider(_attackCollider, new ContactFilter2D(), collisions);

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
