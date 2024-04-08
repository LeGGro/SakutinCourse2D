using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class CoinCollector : MonoBehaviour
{
    [SerializeField] public float CollectedCoinsAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            CollectedCoinsAmount += coin.Value;
            Destroy(collision.gameObject);
        }
    }
}
