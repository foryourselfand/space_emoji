using UnityEngine;

public class FloatOpacityChanger : FloatChanger
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
        var tmp = _spriteRenderer.color;
        tmp.a = current;
        _spriteRenderer.color = tmp;
    }
}