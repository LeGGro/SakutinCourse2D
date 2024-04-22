using System;
using Unity.Mathematics;
using UnityEngine;

public class DirectionFlipper : MonoBehaviour
{
    [SerializeField] private bool _invert = false;

    private Quaternion _negativeRotation = Quaternion.Euler(0, 180, 0);
    private Quaternion _positiveRotation = Quaternion.Euler(0, 0, 0);
    private float _lastDirection;

    public void Flip(float direction)
    {
        if (Math.Sign(direction) != Math.Sign(_lastDirection))
        {
            if (direction > 0)
            {
                transform.rotation = _invert ? _negativeRotation: _positiveRotation;
            }
            else
            {
                transform.rotation = _invert ? _positiveRotation : _negativeRotation;
            }
        }

        _lastDirection = Math.Sign(direction);
    }
}
