using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.Common.Bases
{
    public abstract class CombatatorBase : MonoBehaviour
    {
        public bool IsAttacking { get; protected set; }
        public abstract void GetDamage(float damage);
        public abstract bool Attack();
    }
}