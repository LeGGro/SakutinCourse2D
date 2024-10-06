using Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers;
using UnityEngine;


public abstract class BarBase : MonoBehaviour
{
    [SerializeField] protected Indicator Indicator;

    protected void OnDisable()
    {
        Indicator.ValueChanged -= Output;
        Indicator.BorderChanged -= UpdateIndicatorBorders;
    }

    protected void OnEnable()
    {
        Indicator.ValueChanged += Output;
        Indicator.BorderChanged += UpdateIndicatorBorders;
    }

    protected abstract void Output();
    protected abstract void UpdateIndicatorBorders();
}
