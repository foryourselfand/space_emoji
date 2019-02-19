using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class UpdatingOpacity : SpriteOpacityChanger
{
    public Vector2Prefab targetOffSet;
    public FloatPrefab speedOffSet;

    private void OnBecameVisible()
    {
        if (Random.Range(0, 2) == 0)
            SetTarget(targetOffSet.value.x + targetOffSet.value.y);
        else
            SetTarget(targetOffSet.value.x - targetOffSet.value.y);
        Speed = Random.Range(Speed - speedOffSet.value, Speed + speedOffSet.value);
    }

    private void OnBecameInvisible()
    {
        StopChanging();
    }

    protected override void OnEnd()
    {
        base.OnEnd();
        if (CurrentValue == targetOffSet.value.x + targetOffSet.value.y)
            SetTarget(targetOffSet.value.x - targetOffSet.value.y);
        else if (CurrentValue == targetOffSet.value.x - targetOffSet.value.y)
            SetTarget(targetOffSet.value.x + targetOffSet.value.y);
    }
}