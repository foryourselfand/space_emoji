using UnityEngine;

public class PositionXChanger : PositionChanger
{
    protected override float GetCurrentRef()
    {
        return Transform.localPosition.x;
    }

    protected override void SetCurrentRef(float current)
    {
        var temp = Transform.localPosition;
        temp.x = current;
        Transform.localPosition = temp;
    }
}