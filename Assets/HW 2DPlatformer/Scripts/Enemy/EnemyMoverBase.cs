using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMoverBase : MonoBehaviour
{
    public abstract void Move(Vector2 direction);
    public abstract void Initialize(float speed, Rigidbody2D rigidbody);
}
