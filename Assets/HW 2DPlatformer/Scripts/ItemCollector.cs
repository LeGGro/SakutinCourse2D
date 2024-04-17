using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Player))]
public class ItemCollector : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            _player.CollectItem(item._itemType);
            Destroy(item.gameObject);
        }
    }
}
