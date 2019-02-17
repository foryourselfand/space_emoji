using UnityEngine;

public class CanvasOpacityChanger : FloatChanger
{
    private CanvasGroup _canvasGroup;

    public override void DefineChangingValue()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    protected override float GetCurrentRef()
    {
        return _canvasGroup.alpha;
    }

    protected override void SetCurrentRef(float current)
    {
        _canvasGroup.alpha = current;
    }
}