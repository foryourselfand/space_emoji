using UnityEngine;

public class RotationChanger : TransformChanger
{
    protected override float GetCurrentRef()
    {
        return Transform.eulerAngles.z;
    }

    protected override void SetCurrentRef(float current)
    {
        Transform.rotation = Quaternion.Euler(0, 0, current);
    }
}