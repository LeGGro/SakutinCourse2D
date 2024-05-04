using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _currentHitpointAmount;
        [SerializeField] private float _minHealth = 0;

        public bool IsAlive { get { return _currentHitpointAmount > _minHealth; } }

        public void DealDamage(float damage)
        {
            _currentHitpointAmount = Mathf.Clamp(_currentHitpointAmount - damage, _minHealth, _currentHitpointAmount);

            if (IsAlive == false)
            {
                Destroy(gameObject);
            }
        }

        public void DealHeal(float heal)
        {
            _currentHitpointAmount = Mathf.Clamp(_currentHitpointAmount + heal, _currentHitpointAmount, _maxHealth);
        }
    }
}