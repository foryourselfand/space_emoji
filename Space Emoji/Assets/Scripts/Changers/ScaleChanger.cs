using UnityEngine;

public class ScaleChanger : Changer
{
    private Vector3 _target;
    private Transform _transformRef;
    private Vector3 _upBound;

    private void Awake()
    {
        _transformRef = GetComponent<RectTransform>();
        _upBound = _transformRef.localScale;
    }

    protected override void Change(float t)
    {
        _transformRef.localScale = Vector3.MoveTowards(_transformRef.localScale, _target, Speed * t);
    }

    protected override bool Condition()
    {
        return Vector3.SqrMagnitude(_transformRef.localScale - _target) > Vector3.kEpsilon;
    }

    protected override void OnEnd()
    {
        _transformRef.localScale = _target;
    }

    public void SetCurrent(Vector3 current)
    {
        _transformRef.localScale = current;
    }

    public void SetTargetAndAction(ScaleType type)
    {
        _target = type == ScaleType.Up ? _upBound : Vector3.zero;
        StartChanging();
    }
}