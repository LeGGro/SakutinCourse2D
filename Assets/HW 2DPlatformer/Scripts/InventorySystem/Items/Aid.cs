using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.InventorySystem
{
    [CreateAssetMenu(fileName = "Aid", menuName = "ScriptableObjects/Items/Aid", order = 2)]
    public class Aid : ItemBase
    {
        [SerializeField] private int _value;

        public int Value { get => _value; }
    }
}
