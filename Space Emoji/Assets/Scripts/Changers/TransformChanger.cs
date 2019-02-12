using UnityEngine;

public abstract class TransformChanger : FloatChanger
{
    protected Transform Transform;

    protected override void DefineChangingValue()
    {
        Transform = GetComponent<Transform>();
    }
}