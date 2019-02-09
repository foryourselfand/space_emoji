using UnityEngine;

public class OpacityChanger : Changer
{
    private float Opacity
    {
        get { return _current; }
        set
        {
            _current = value;
            SetOpacityRef(value);
        }
    }

    private float _current;
    private float _target;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _current = _spriteRenderer.color.a;
    }

    private void SetOpacityRef(float current)
    {
        var tmp = _spriteRenderer.color;
        tmp.a = current;
        _spriteRenderer.color = tmp;
    }

    protected override bool Condition()
    {
        return Mathf.Abs(Opacity - _target) > 0.01F;
    }

    protected override void Change(float t)
    {
        Opacity = Mathf.MoveTowards(Opacity, _target, t * speed);
    }

    protected override void OnEnd()
    {
        Opacity = _target;
    }

    public void SetCurrent(float current)
    {
        Opacity = current;
    }

    public void SetTarget(float target)
    {
        _target = target;
        StartChanging();
    }

    public void SetCurrentAndTarget(float current, float target)
    {
        SetCurrent(current);
        SetTarget(target);
    }
}