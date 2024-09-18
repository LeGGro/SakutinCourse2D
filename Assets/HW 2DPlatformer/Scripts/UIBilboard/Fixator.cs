using UnityEngine;

public class Fixator : MonoBehaviour
{
    [SerializeField] private bool _fixateRotations = true;
    [SerializeField] private bool _fixatePositions = false;
    [SerializeField] private bool _fixateScales = false;

    private Vector3 _position;
    private Quaternion _rotation;
    private Vector3 _scale;

    private void Start()
    {
        _position = transform.position;
        _rotation = transform.rotation;
        _scale = transform.localScale;
    }

    private void Update()
    {
        if (_fixateRotations && _rotation != transform.rotation) 
        {
            transform.rotation = _rotation;
        }

        if (_fixatePositions && _position != transform.position)
        {
            transform.position = _position;
        }

        if (_fixateScales && _scale != transform.localScale)
        {
            transform.localScale = _scale;
        }
    }
}
