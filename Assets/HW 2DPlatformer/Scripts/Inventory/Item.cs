using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemBase _itemType;
    [SerializeField] private int _count;

    public int ItemTypeId { get => _itemType.Id; }
    public int ItemCount { get => _count; }
}
