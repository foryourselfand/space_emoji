using UnityEngine;

public abstract class TransformChanger : FloatChanger
{
    protected Transform Transform;

    public override void DefineChangingValue()
    {
        Transform = GetComponent<Transform>();
    }
}