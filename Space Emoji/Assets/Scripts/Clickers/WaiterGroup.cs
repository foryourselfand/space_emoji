using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WaiterGroup : MonoBehaviour
{
    public float timeToWait;

    private List<ScaleChanger> _buttons;

    private ScaleType _scaleType;

    private void Awake()
    {
        _buttons = Helper.GetChildrenFromParent<ScaleChanger>(gameObject);
    }

    private void Start()
    {
        foreach (var button in _buttons)
            button.SetCurrent(Vector3.zero);
        _scaleType = ScaleType.Up;
    }

    public IEnumerator Trigger()
    {
        foreach (var button in _buttons)
        {
            button.SetTargetAndAction(_scaleType);
            yield return new WaitForSeconds(timeToWait);
        }

        _buttons.Reverse();
        _scaleType = _scaleType == ScaleType.Up ? ScaleType.Down : ScaleType.Up;
    }

    public IEnumerator IsDone()
    {
        foreach (var button in _buttons)
            yield return new WaitUntil(button.IsDone);
    }
}