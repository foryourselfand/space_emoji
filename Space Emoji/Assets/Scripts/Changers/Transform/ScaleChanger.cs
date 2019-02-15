using UnityEngine;

public class ScaleChanger : TransformChanger
{
    protected override float GetCurrentRef()
    {
        return Transform.localScale.x;
    }

    protected override void SetCurrentRef(float current)
    {
        Transform.localScale = new Vector3(current, current);
    }

    public void SetTypeTarget(ScaleType scaleType)
    {
        if (scaleType == ScaleType.Up)
            SetTargetToStart();
        else
            SetTarget(0);
    }
}