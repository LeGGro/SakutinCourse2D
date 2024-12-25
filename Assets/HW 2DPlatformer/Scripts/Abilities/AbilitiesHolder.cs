using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Abilities
{
    public class AbilitiesHolder : MonoBehaviour
    {
        [SerializeField] private Transform _playerLocation;
        [SerializeField] private Transform _containerPrefab;
        [SerializeField] private AbilitiesUIDrawer _drawer;
        [SerializeField] private List<AbilityScriptableObjectBase> _abilities;
        

        private void Start()
        {
            Initialize();
        }

        public void ActivateAbility(int number)
        {
            _abilities[number]?.Activate?.Invoke();
        }

        public void Initialize()
        {
            _drawer.AddBaseComponents();

            foreach (var ability in _abilities)
            {
                ability.Initialize(CreateScriptContainer(), _playerLocation, _drawer.CreateUIContainer());
            }
        }

        private Transform CreateScriptContainer()
        {
            return Instantiate(_containerPrefab, this.transform);
        }
    }
}