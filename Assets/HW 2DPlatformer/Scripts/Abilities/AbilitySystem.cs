using Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class AbilitySystem : MonoBehaviour
{
    [SerializeField] private AbilityScriptableObjectBase _firstAbility;
    [SerializeField] private Indicator _firstIndicator;
    [SerializeField] private AbilityScriptableObjectBase _secondAbility;
    [SerializeField] private Indicator _secondIndicator;

    public Indicator Health { get; private set; }

    public void Initialize(Indicator health, AbilityScriptableObjectBase first = null, AbilityScriptableObjectBase second = null)
    {
        if (first != null) 
        {
            _firstAbility = first;
        }

        if (second != null) 
        {
            _secondAbility = second;
        }

        if (_firstAbility != null) 
        {
            _firstAbility.Initialize(this, _firstIndicator);
        }

        if (_secondAbility != null) 
        {
            _secondAbility.Initialize(this, _secondIndicator);
        }

        Health = health;
    }

    public void Activate(AbilityBindNumber ability)
    {
        switch (ability) 
        {
            case AbilityBindNumber.First:
                _firstAbility.Activate();
                break;
            
            case AbilityBindNumber.Second:
                _secondAbility.Activate();
                break;
        }
    }
}

public enum AbilityBindNumber
{
    First, 
    Second
}
