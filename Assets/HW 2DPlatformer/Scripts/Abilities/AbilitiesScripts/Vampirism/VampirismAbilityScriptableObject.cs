using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "VampirismAbility", menuName = "ScriptableObjects/Abilities/Vampirism", order = 1)]
public class VampirismAbilityScriptableObject : AbilityScriptableObjectBase
{
    [field: SerializeField] public float CircleRadius { get; private set; }
    [field: SerializeField] public float DamagePerSecond { get; private set; }
    [field: SerializeField] public float SmoothnessValue { get; private set; }
    [field: SerializeField] public float ActionDuration { get; private set; }
    [field: SerializeField] public float CooldownDuration { get; private set; }

    public Transform ScriptLocation { get; private set; }
    public Transform PlayerLocation { get; private set; }

    public override void Initialize(Transform scriptLocation, Transform playerLocation, BarBase outputBar)
    {
        ScriptLocation = scriptLocation;
        PlayerLocation = playerLocation;

        if (scriptLocation.TryGetComponent(out VampirismAbilityScript abilityScript) == false)
        {
            AbilityScript = scriptLocation.AddComponent<VampirismAbilityScript>();
        }
        else
        {
            AbilityScript = abilityScript;
        }

        AbilityScript.Initialize(this, outputBar);
        Activate += new ActivateDelegate(AbilityScript.Activate);
    }
}
