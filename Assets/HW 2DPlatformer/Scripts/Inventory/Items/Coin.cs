using UnityEngine;

[CreateAssetMenu(fileName = "Coin", menuName = "ScriptableObjects/Items/Coin", order = 1)]
public class Coin : ItemBase
{
    [SerializeField] private int _value;

    public int Value { get => _value; }
}
