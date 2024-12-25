using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothBar : BarBase
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _time;
    [SerializeField] private float _maxDelta;

    private WaitForSeconds _delay;
    private Coroutine _coroutine;
    private float _currentBarValue;

    protected override void Output()
    {
        _delay = new WaitForSeconds(_time / Mathf.Abs(Indicator.CurrentValue - _slider.value));
        _currentBarValue = Indicator.CurrentValue;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SmoothChanging());
    }

    protected override void UpdateBarBorders()
    {
        _slider.maxValue = Indicator.MaxValue;
        _slider.minValue = Indicator.MinValue;
    }

    private IEnumerator SmoothChanging()
    {
        while (_slider.value != _currentBarValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _currentBarValue, _maxDelta);
            yield return _delay;
        }

        _coroutine = null;
    }
}
