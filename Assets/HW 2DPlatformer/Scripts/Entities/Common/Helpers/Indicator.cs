using System;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers
{
    public class Indicator : MonoBehaviour
    {
        [field: SerializeField] public float MaxValue { get; private set; }
        [field: SerializeField] public float CurrentValue { get; private set; }
        [field: SerializeField] public float MinValue { get; private set; }
        [field: SerializeField] public bool CanDie { get; private set; }

        public event Action ValueChanged;
        public event Action BorderChanged;
        public bool IsZero { get => CurrentValue > MinValue; }

        public void Setup(float maxValue, float currentValue, float minValue)
        {
            MaxValue = maxValue;
            CurrentValue = currentValue;
            MinValue = minValue;
            ValueChanged?.Invoke();
            BorderChanged?.Invoke();
        }

        public void Substruct(float value)
        {
            if (value <= 0)
                return;

            CurrentValue = Mathf.Clamp(CurrentValue - value, MinValue, CurrentValue);
            ValueChanged?.Invoke();

            if (IsZero == false && CanDie == true)
                Destroy(gameObject);
        }

        public void Add(float value)
        {
            if (value <= 0)
                return;

            CurrentValue = Mathf.Clamp(CurrentValue + value, CurrentValue, MaxValue);
            ValueChanged?.Invoke();
        }
    }
}