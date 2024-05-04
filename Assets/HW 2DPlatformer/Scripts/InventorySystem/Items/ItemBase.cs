using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.InventorySystem
{
    public abstract class ItemBase : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private string _name;
        [SerializeField] private string _description;

        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
    }
}