using System;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers
{
    public class Indicator : MonoBehaviour
    {

        public event Action ValueChanged;
        public event Action BorderChanged;

        [field: SerializeField] public float MaxValue { get; private set; }
        [field: SerializeField] public float CurrentValue { get; private set; }
        [field: SerializeField] public float MinValue { get; private set; }
        [field: SerializeField] public bool CanDie { get; private set; }

        public bool IsZero { get => CurrentValue > MinValue; }

        public void Initialize(float maxValue = -1, float currentValue = -1, float minValue = -1)
        {
            MaxValue = maxValue == -1? MaxValue: maxValue;
            CurrentValue = currentValue == -1 ? CurrentValue : currentValue;
            MinValue = minValue == -1 ? MinValue : minValue;
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