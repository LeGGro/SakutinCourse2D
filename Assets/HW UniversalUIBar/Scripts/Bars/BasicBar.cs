using UnityEngine;
using UnityEngine.UI;

public class BasicBar : BarBase
{
    [SerializeField] private Slider _slider;

    protected override void Output()
    {
        _slider.maxValue = _indicator.GetMaxValue();
        _slider.minValue = _indicator.GetMinValue();
        _slider.value = _indicator.GetCurrentValue();
    }
}
