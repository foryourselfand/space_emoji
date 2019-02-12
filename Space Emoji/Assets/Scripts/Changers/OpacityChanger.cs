using UnityEngine;

public class OpacityChanger : FloatChanger
{
    private SpriteRenderer _spriteRenderer;

    protected override void DefineChangingValue()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override float GetCurrentRef()
    {
        return _spriteRenderer.color.a;
    }

    protected override void SetCurrentRef(float current)
    {
        var temp = _spriteRenderer.color;
        temp.a = current;
        _spriteRenderer.color = temp;
    }
}