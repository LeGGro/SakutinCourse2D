using Unity.Mathematics;
using UnityEngine;

public class DirectionFlipper : MonoBehaviour
{
    private float _lastDirection;

    public void Flip(float direction)
    {
        if (math.sign(direction) != math.sign(_lastDirection))
        {
            if (direction > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        _lastDirection = math.sign(direction);
    }
}
