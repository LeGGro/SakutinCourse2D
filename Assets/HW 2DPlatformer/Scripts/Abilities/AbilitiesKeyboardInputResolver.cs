using Assets.HW_2DPlatformer.Scripts.Abilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesKeyboardInputResolver : MonoBehaviour
{
    [field: SerializeField] private List<KeyCode> _abilityKeyBindBases;
    [SerializeField] private AbilitiesHolder _abilitiesHolder;

    void Update()
    {
        if (Input.anyKey)
        {
            for (int i = 0; i < _abilityKeyBindBases.Count; i++)
            {
                if (Input.GetKeyDown(_abilityKeyBindBases[i]))
                {
                    _abilitiesHolder.ActivateAbility(i);
                }
            }
        }
    }
}
