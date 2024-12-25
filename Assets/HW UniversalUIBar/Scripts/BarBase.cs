using Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers;
using UnityEngine;


public abstract class BarBase : MonoBehaviour
{
    [SerializeField] protected Indicator Indicator;

    public void Inititialize(Indicator indicator)
    {
        Indicator = indicator;
        Indicator.ValueChanged += Output;
        Indicator.BorderChanged += UpdateBarBorders;
    }

    protected void OnDisable()
    {
        Indicator.ValueChanged -= Output;
        Indicator.BorderChanged -= UpdateBarBorders;
    }

    protected void OnEnable()
    {
        Indicator.ValueChanged += Output;
        Indicator.BorderChanged += UpdateBarBorders;
    }

    protected abstract void Output();
    protected abstract void UpdateBarBorders();
}
