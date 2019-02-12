using UnityEngine;

public abstract class FloatChanger : Changer
{
    private float CurrentValue
    {
        get { return GetCurrentRef(); }
        set { SetCurrentRef(value); }
    }

    private float _startValue;

    private float _targetValue;

    private ChangerBehavior _changerBehavior;

    private void Awake()
    {
        DefineChangingValue();
        _startValue = CurrentValue;
        _changerBehavior = GetComponent<ChangerBehavior>();
        if (_changerBehavior == null)
            _changerBehavior = gameObject.AddComponent<MoveTowardsBehavior>();
    }

    protected abstract void DefineChangingValue();
    protected abstract float GetCurrentRef();
    protected abstract void SetCurrentRef(float current);

    protected override bool Condition()
    {
        return Mathf.Abs(CurrentValue - _targetValue) > 0.01F;
    }

    protected override void Change(float t)
    {
        CurrentValue = _changerBehavior.Change(CurrentValue, _targetValue, speed);
    }

    protected override void OnEnd()
    {
        CurrentValue = _targetValue;
    }

    public void SetTarget(float target)
    {
        _targetValue = target;
        StartChanging();
    }

    public void SetTargetFromCurrent(float target)
    {
        _targetValue = CurrentValue + target;
        StartChanging();
    }

    public void SetTargetFromStart(float target)
    {
        _targetValue = _startValue + target;
        StartChanging();
    }
}