using UnityEngine;

public class FloatCameraChanger : FloatChanger
{
    private Camera _camera;

    protected override void DefineChangingValue()
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