using UnityEngine;

public class CameraChanger : Changer
{
    private Camera _camera;
    private float _target;
    private float _start;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _start = _camera.orthographicSize;
    }

    protected override bool Condition()
    {
        return Mathf.Abs(_camera.orthographicSize - _target) > 0.01F;
    }

    protected override void Change(float t)
    {
        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, _target, t * speed);
    }

    protected override void OnEnd()
    {
        _camera.orthographicSize = _target;
    }

    public void SetTargetFromStart(float value)
    {
        _target = _start + value;
        StartChanging();
    }
}