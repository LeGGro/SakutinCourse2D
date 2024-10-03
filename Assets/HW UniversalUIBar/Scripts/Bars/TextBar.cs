using TMPro;
using UnityEngine;

public class TextBar : BarBase
{
    [SerializeField] private TMP_Text _text;

    protected override void Output()
    {
        _text.text = $"{_indicator.GetCurrentValue()}/{_indicator.GetMaxValue()}";
    }
}
