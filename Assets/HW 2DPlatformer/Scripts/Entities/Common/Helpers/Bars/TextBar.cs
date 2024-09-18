using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBar : BarBase
{
    [SerializeField] private TMP_Text _text;

    public override void Output(float maxBarValue, float minBarValue, float currentBarValue)
    {
        _text.text = $"{currentBarValue}/{maxBarValue}";
    }
}
