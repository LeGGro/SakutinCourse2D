using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string JumpAxisName = "Jump";

    public float HorizontalAxis { get; private set; }
    public float VerticalAxis { get; private set; }

    private void Update()
    {
        HorizontalAxis = Input.GetAxisRaw(HorizontalAxisName);
        VerticalAxis = Input.GetAxisRaw(JumpAxisName);
    }
}
