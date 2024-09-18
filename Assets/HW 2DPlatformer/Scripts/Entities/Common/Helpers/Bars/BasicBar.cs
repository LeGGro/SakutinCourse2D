using UnityEngine;
using UnityEngine.UI;

public class BasicBar : BarBase
{
    [SerializeField] private Slider _slider;

    public override void Output(float maxBarValue, float minBarValue, float currentBarValue)
    {
        _slider.maxValue = maxBarValue;
        _slider.minValue = minBarValue;
        _slider.value = currentBarValue;
    }
}
