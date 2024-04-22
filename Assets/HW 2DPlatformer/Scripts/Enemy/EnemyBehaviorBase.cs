using System.Collections;
using UnityEngine;

public abstract class EnemyBehaviorBase : MonoBehaviour
{
    private Coroutine _currentCoroutine;
    public abstract Vector2 MoveDirection { get; }

    public void Activate()
    {
        _currentCoroutine ??= StartCoroutine(Acting());
    }

    public void Deactivate()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);
    }

    protected abstract IEnumerator Acting();

}
