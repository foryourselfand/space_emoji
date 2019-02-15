using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaiterGroup : MonoBehaviour
{
    public FloatPrefab timeToWait;

    private List<ScaleChanger> _buttons;

    private ScaleType _scaleType;

    private void Awake()
    {
        _buttons = Helper.GetChildrenFromParent<ScaleChanger>(gameObject);
    }

    private void Start()
    {
        foreach (var button in _buttons)
            button.SetCurrent(0);
        _scaleType = ScaleType.Up;
    }

    public IEnumerator Triggering()
    {
        for (var i = 0; i < _buttons.Count; i++)
        {
            _buttons[i].SetTypeTarget(_scaleType);
            yield return new WaitForSeconds(timeToWait.value);
        }

        _buttons.Reverse();
        _scaleType = _scaleType == ScaleType.Up ? ScaleType.Down : ScaleType.Up;
    }

    public IEnumerator IsAllFinished()
    {
        for (var i = 0; i < _buttons.Count; i++)
        {
            yield return new WaitUntil(_buttons[i].IsFinished);
        }
    }
}