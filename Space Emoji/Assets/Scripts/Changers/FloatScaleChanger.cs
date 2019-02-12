using UnityEngine;

public class FloatScaleChanger : FloatChanger
{
    private Transform _transform;

    protected override void DefineChangingValue()
    {
        _transform = GetComponent<Transform>();
    }

    protected override float GetCurrentRef()
    {
        return _transform.localScale.x;
    }

    protected override void SetCurrentRef(float current)
    {
        _transform.localScale = new Vector3(current, current);
    }
}