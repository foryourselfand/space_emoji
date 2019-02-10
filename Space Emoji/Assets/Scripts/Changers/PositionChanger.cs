using UnityEngine;

public class PositionChanger : Changer
{
    private Transform _transform;
    private Vector3 _target;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    protected override bool Condition()
    {
        return Vector3.SqrMagnitude(_transform.localPosition - _target) > Vector3.kEpsilon;
    }

    protected override void Change(float t)
    {
        _transform.localPosition = Vector3.MoveTowards(_transform.localPosition, _target, speed * t);
    }

    protected override void OnEnd()
    {
        _transform.localPosition = _target;
    }

    public void SetTargetFromCurrent(Vector3 target)
    {
        _target = _transform.localPosition + target;
        StartChanging();
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
        StartChanging();
    }
}