using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Bases
{
    public abstract class EnemyMoverBase : MonoBehaviour
    {
        public abstract void Move(Vector2 direction);
        public abstract void Initialize(float speed, Rigidbody2D rigidbody);
    }
}