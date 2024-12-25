using Assets.HW_2DPlatformer.Scripts.Entities.PlayerRep;
using System;
using UnityEngine;

public abstract class AbilityScriptBase: MonoBehaviour
{
    public abstract void Activate();
    public abstract void Initialize(AbilityScriptableObjectBase scriptableObject, BarBase outputBar);
}