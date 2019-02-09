using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

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
            OnEnd();
            _changing = false;
        }
    }

    protected abstract bool Condition();

    protected abstract void Change(float t);

    protected abstract void OnEnd();

    protected void StartChanging()
    {
        _changing = true;
    }

    public bool IsDone()
    {
        return _changing == false;
    }
}