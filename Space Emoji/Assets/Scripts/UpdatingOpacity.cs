using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class UpdatingOpacity : SpriteOpacityChanger
{
    public Vector2Prefab offSet;

    private void OnBecameVisible()
    {
        if (Random.Range(0, 2) == 0)
            SetTarget(offSet.value.x + offSet.value.y);
        else
            SetTarget(offSet.value.x - offSet.value.y);
    }

    private void OnBecameInvisible()
    {
        StopChanging();
    }

    protected override void OnEnd()
    {
        base.OnEnd();
        if (CurrentValue == offSet.value.x + offSet.value.y)
            SetTarget(offSet.value.x - offSet.value.y);
        else if (CurrentValue == offSet.value.x - offSet.value.y)
            SetTarget(offSet.value.x + offSet.value.y);
    }
}