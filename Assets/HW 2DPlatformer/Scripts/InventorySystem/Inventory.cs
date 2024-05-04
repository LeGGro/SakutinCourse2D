using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int _inventoryMaxCount;

        private Dictionary<int, int> _keyValuePairs = new Dictionary<int, int>();

        public bool AddItem(int id, int value)
        {
            if (_keyValuePairs.ContainsKey(id) == false)
            {
                if (_inventoryMaxCount <= _keyValuePairs.Count)
                {
                    return false;
                }
                else
                {
                    _keyValuePairs.Add(id, value);
                    return true;
                }
            }
            else
            {
                _keyValuePairs[id] += value;
                return true;
            }
        }
    }
}
