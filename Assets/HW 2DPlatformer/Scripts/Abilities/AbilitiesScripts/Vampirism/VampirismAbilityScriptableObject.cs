using Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "VampirismAbility", menuName = "ScriptableObjects/Abilities/Vampirism", order = 1)]
public class VampirismAbilityScriptableObject : AbilityScriptableObjectBase
{
    private VampirismAbilityScript _script;
    private AbilitySystem _system;
    private Indicator _indicator;

    [field: SerializeField] public float CircleRadius { get; private set; }
    [field: SerializeField] public float DamagePerSecond { get; private set; }
    [field: SerializeField] public float SmoothnessValue { get; private set; }
    [field: SerializeField] public float ActionDuration { get; private set; }
    [field: SerializeField] public float CooldownDuration { get; private set; }

    public override void Initialize(AbilitySystem abilitySystem, Indicator indicator)
    {
        if (abilitySystem.TryGetComponent(out _script) == false)
        {
            _script = abilitySystem.AddComponent<VampirismAbilityScript>();
        }

        _indicator = indicator;
        _system = abilitySystem;
        _script.Initialize(this, _system, _indicator);
    }

    public override void Activate()
    {
        _script.Activate();
    }
}
