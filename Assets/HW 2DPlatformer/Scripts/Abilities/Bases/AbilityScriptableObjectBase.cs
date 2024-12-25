using Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers;
using System;
using UnityEngine;

public delegate void ActivateDelegate();

public abstract class AbilityScriptableObjectBase : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private string _name;
    [SerializeField] private string _description;

    public AbilityScriptBase AbilityScript { get; protected set; }
    public ActivateDelegate Activate { get; protected set; }

    public abstract void Initialize(Transform scriptLocation, Transform playerLocation, BarBase outputBar);
}
