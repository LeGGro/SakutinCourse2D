using System.Collections;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.EnemyRep.Bases
{
    public abstract class EnemyBehaviorBase : MonoBehaviour
    {
        [SerializeField] protected bool _freezeY, _freezeX;

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
            _currentCoroutine = null;
        }

        protected abstract IEnumerator Acting();

    }
}
