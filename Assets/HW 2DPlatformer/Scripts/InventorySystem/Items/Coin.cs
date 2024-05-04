using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.InventorySystem
{
    [CreateAssetMenu(fileName = "Coin", menuName = "ScriptableObjects/Items/Coin", order = 1)]
    public class Coin : ItemBase
    {
        [SerializeField] private int _value;

        public int Value { get => _value; }
    }
}
