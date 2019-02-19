using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Changer : MonoBehaviour
{
    public FloatPrefab prefabSpeed;
    protected float Speed;

    private bool _changing;

    private void Update()
    {
        if (!_changing) return;
        if (Condition())
            Change();
        else
        {
            _changing = false;
            OnEnd();
        }
    }

    protected abstract bool Condition();

    protected abstract void Change();

    protected abstract void OnEnd();

    protected void StartChanging()
    {
        _changing = true;
    }
    
    protected void StopChanging()
    {
        _changing = false;
    }


    public bool IsFinished()
    {
        return _changing == false;
    }
}