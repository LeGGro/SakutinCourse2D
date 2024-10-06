using UnityEngine;
using UnityEngine.UI;

public class BasicBar : BarBase
{
    [SerializeField] private Slider _slider;

    protected override void Output()
    {
        _slider.value = Indicator.CurrentValue;
    }

    protected override void UpdateIndicatorBorders()
    {
        _slider.maxValue = Indicator.MaxValue;
        _slider.minValue = Indicator.MinValue;
    }
}
