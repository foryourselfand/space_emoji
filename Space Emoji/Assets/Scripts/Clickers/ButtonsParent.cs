using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsParent : MonoBehaviour
{
    public float TimeToWait;

    private List<ScaleChanger> _buttons;

    private void Awake()
    {
        _buttons = Helper.GetChildrenFromParent<ScaleChanger>(gameObject);
    }

    private void Start()
    {
        foreach (var button in _buttons)
            button.SetCurrent(Vector3.zero);
    }

    public IEnumerator ShowButtons()
    {
        foreach (var button in _buttons)
        {
            button.SetTargetAndAction(ScaleChanger.ScaleType.Up);
            yield return new WaitForSeconds(TimeToWait);
        }

        foreach (var button in _buttons)
            yield return new WaitUntil(button.IsDone);
    }
}