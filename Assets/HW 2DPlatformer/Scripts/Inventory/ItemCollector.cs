using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Inventory))]
public class ItemCollector : MonoBehaviour
{
    private Inventory _inventory;

    private void Start()
    {
        _inventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            if (_inventory.AddItem(item.ItemTypeId, item.ItemCount) == true)
            {
                Destroy(item.gameObject);
            }
        }
    }
}
