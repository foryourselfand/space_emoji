using UnityEngine;

public abstract class FloatChanger : Changer
{
    protected float CurrentValue
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
        Speed = prefabSpeed.value;
        _startValue = CurrentValue;
        _changerBehavior = GetComponent<ChangerBehavior>();
        if (_changerBehavior == null)
            _changerBehavior = gameObject.AddComponent<MoveTowardsBehavior>();
    }

    public abstract void DefineChangingValue();
    protected abstract float GetCurrentRef();
    protected abstract void SetCurrentRef(float current);

    protected override bool Condition()
    {
        return Mathf.Abs(CurrentValue - _targetValue) > 0.01F;
    }

    protected override void Change()
    {
        CurrentValue = _changerBehavior.Change(CurrentValue, _targetValue, Speed);
    }

    protected override void OnEnd()
    {
        CurrentValue = _targetValue;
    }

    public void SetCurrent(float current)
    {
        CurrentValue = current;
    }

    public void SetTarget(float target)
    {
        _targetValue = target;
        StartChanging();
    }

    public void SetTargetToStart()
    {
        SetTarget(_startValue);
    }

    public void SetTargetFromCurrent(float target)
    {
        SetTarget(CurrentValue + target);
    }

    public void SetTargetFromStart(float target)
    {
        SetTarget(_startValue + target);
    }

    public void AddToCurrent(float increment)
    {
        CurrentValue += increment;
    }
}