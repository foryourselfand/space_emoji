using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

    public IEnumerator Triggering()
    {
        foreach (var button in _buttons)
        {
            button.SetTarget(_scaleType);
            yield return new WaitForSeconds(timeToWait);
        }

        _buttons.Reverse();
        _scaleType = _scaleType == ScaleType.Up ? ScaleType.Down : ScaleType.Up;
    }

    public IEnumerator IsAllFinished()
    {
        foreach (var button in _buttons.ToList())
        {
            yield return new WaitUntil(button.IsFinished);
        }
    }
}