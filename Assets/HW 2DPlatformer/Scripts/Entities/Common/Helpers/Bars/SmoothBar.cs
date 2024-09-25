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

    public override void Output(float maxBarValue, float minBarValue, float currentBarValue)
    {
        _slider.maxValue = maxBarValue;
        _slider.minValue = minBarValue;
        _delay = new WaitForSeconds(_time / Mathf.Abs(currentBarValue - _slider.value));
        _currentBarValue = currentBarValue;

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
