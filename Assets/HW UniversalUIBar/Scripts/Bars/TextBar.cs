using TMPro;
using UnityEngine;

public class TextBar : BarBase
{
    [SerializeField] private TMP_Text _text;

    protected override void Output()
    {
        _text.text = $"{Indicator.CurrentValue}/{Indicator.MaxValue}";
    }

    protected override void UpdateBarBorders()
    {
        Indicator.BorderChanged -= this.UpdateBarBorders;
    }
}
