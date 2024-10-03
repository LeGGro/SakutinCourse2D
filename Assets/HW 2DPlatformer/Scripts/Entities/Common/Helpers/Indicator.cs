using System;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers
{
    public class Indicator : MonoBehaviour
    {
        [SerializeField] private float _maxValue;
        [SerializeField] private float _currentValue;
        [SerializeField] private float _minValue;

        public event Action ValueChanged;
        public bool IsZero { get => GetCurrentValue() > GetMinValue(); }

        private void Start()
        {
            ValueChanged?.Invoke();
        }
        public float GetMaxValue()
        {
            return _maxValue;
        }

        public float GetCurrentValue()
        {
            return _currentValue;
        }

        public float GetMinValue()
        {
            return _minValue;
        }

        public void Substruct(float value)
        {
            if (value <= 0)
                return;

            _currentValue = Mathf.Clamp(_currentValue - value, _minValue, _currentValue);
            ValueChanged?.Invoke();

            if (IsZero == false)
                Destroy(gameObject);
        }

        public void Add(float value)
        {
            if (value <= 0)
                return;

            _currentValue = Mathf.Clamp(_currentValue + value, _currentValue, _maxValue);
            ValueChanged?.Invoke();
        }
    }
}