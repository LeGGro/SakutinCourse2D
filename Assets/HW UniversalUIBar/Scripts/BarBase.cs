using Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers;
using UnityEngine;


public abstract class BarBase : MonoBehaviour
{
    [SerializeField] protected Indicator _indicator;

    protected void OnDisable()
    {
        _indicator.ValueChanged -= Output;
    }

    protected void OnEnable()
    {
        _indicator.ValueChanged += Output;
    }

    protected abstract void Output();
}
