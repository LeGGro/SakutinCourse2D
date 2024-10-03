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
        _slider.minValue = _indicator.GetMinValue();
        _slider.maxValue = _indicator.GetMaxValue();
        _delay = new WaitForSeconds(_time / Mathf.Abs(_indicator.GetCurrentValue() - _slider.value));
        _currentBarValue = _indicator.GetCurrentValue();

        if (_coroutine == null)
            _coroutine = StartCoroutine(SmoothChanging());
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
