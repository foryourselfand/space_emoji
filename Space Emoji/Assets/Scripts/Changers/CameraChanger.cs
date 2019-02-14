using UnityEngine;

public class CameraChanger : FloatChanger
{
    private Camera _camera;

    public override void DefineChangingValue()
    {
        _camera = GetComponent<Camera>();
    }

    protected override float GetCurrentRef()
    {
        return _camera.orthographicSize;
    }

    protected override void SetCurrentRef(float current)
    {
        _camera.orthographicSize = current;
    }
}