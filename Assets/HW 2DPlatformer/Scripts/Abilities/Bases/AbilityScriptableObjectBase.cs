using Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers;
using UnityEngine;

public abstract class AbilityScriptableObjectBase : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    public abstract void Activate();
    public abstract void Initialize(AbilitySystem abilitySystem, Indicator indicator);
}
