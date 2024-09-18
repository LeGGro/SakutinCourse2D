using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BarBase : MonoBehaviour
{
    //protected BarBase(int maxBarValue, int minBarValue, float lastValue)
    //{
    //    _lastValue = lastValue;
    //    Output(maxBarValue, minBarValue, lastValue);
    //}

    public abstract void Output(float maxBarValue, float minBarValue, float currentBarValue);
}
