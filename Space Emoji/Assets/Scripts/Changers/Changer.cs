using System.Collections;
using UnityEngine;

public abstract class Changer : MonoBehaviour
{
    public float speed;

    private bool _changing;

    private void Update()
    {
        if (!_changing) return;
        if (Condition())
            Change(Time.deltaTime);
        else
        {
            _changing = false;
            OnEnd();
        }
    }

    protected abstract bool Condition();

    protected abstract void Change(float t);

    protected abstract void OnEnd();

    protected void StartChanging()
    {
        _changing = true;
    }

    public bool IsFinished()
    {
        return _changing == false;
    }
}