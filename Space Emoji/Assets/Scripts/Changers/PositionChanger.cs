using UnityEngine;

public abstract class PositionChanger : FloatChanger
{
    protected Transform Transform;

    protected override void DefineChangingValue()
    {
        Transform = GetComponent<Transform>();
    }
}