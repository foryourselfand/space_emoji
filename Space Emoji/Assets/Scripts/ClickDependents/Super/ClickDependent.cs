using UnityEngine;

public abstract class ClickDependent : MonoBehaviour
{
    public FloatPrefab step;

    public abstract void DependentAction(DirectionType selfDirection, float rocketSpeed);
}