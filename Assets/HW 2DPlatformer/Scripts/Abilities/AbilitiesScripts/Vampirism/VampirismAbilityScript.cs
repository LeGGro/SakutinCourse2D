using Assets.HW_2DPlatformer.Scripts.Entities.Common.Bases;
using Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class VampirismAbilityScript : MonoBehaviour
{
    private VampirismAbilityScriptableObject _scriptObject;
    private AbilitySystem _abilitySystem;
    private Indicator _indicator;

    private bool _isActing;
    private bool _isReady;
    private WaitForSeconds _tick;

    private CircleCollider2D _circleCollider;

    private float _damagePerTick;
    private float _actingTickDuration;
    private float _cooldownTickDuration;
    private float _statusIndicator;

    public void Activate()
    {
        if (_isReady == true && _isActing == false)
        {
            StartCoroutine(Acting());
        }
    }

    public void Setup(VampirismAbilityScriptableObject scriptableObject, AbilitySystem abilitySystem, Indicator indicator)
    {
        _abilitySystem = abilitySystem;
        _scriptObject = scriptableObject;
        _indicator = indicator;

        _indicator.Setup(_scriptObject.ActionDuration, _statusIndicator, 0);

        if (TryGetComponent(out _circleCollider) == false)
        {
            _circleCollider = this.AddComponent<CircleCollider2D>();
        }

        _circleCollider.radius = _scriptObject.CircleRadius;
        _circleCollider.enabled = false;
        _circleCollider.isTrigger = true;

        _isReady = true;
        _isActing = false;
        _actingTickDuration = 1.0f / _scriptObject.SmoothnessValue;
        _cooldownTickDuration = _scriptObject.ActionDuration / _scriptObject.CooldownDuration / _scriptObject.SmoothnessValue;
        _damagePerTick = _scriptObject.DamagePerSecond / _scriptObject.SmoothnessValue;
        _tick = new WaitForSeconds(_actingTickDuration);
    }

    private IEnumerator Acting()
    {
        _isActing = true;
        _isReady = false;
        List<Collider2D> results = new List<Collider2D>();
        _circleCollider.enabled = true;

        while (_indicator.CurrentValue > 0)
        {
            _circleCollider.GetContacts(results);

            if (results.Count != 0)
            {
                results.OrderByDescending(x => (x.transform.position - this.transform.position).magnitude);
                CombatatorBase controller = null;
                results.First(x => x.TryGetComponent(out controller) == true);

                if (controller != null)
                {
                    _abilitySystem.Health.Add(_damagePerTick);
                    controller.DealDamage(_damagePerTick);
                }
            }

            yield return _tick;
            _indicator.Substruct(_actingTickDuration);
        }

        _circleCollider.enabled = false;
        _isActing = false;
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        while (_indicator.CurrentValue < _scriptObject.ActionDuration)
        {
            yield return _tick;
            _indicator.Add(_cooldownTickDuration);
        }

        _isReady = true;
    }
}
