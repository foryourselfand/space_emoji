using System.Collections;
using UnityEngine;

public class SpaceManager : MonoBehaviour
{
    public PositionYChanger parentFirst, parentSecond;

    public void StartMove()
    {
        StartCoroutine(Moving(parentFirst, -10));
        StartCoroutine(Moving(parentSecond, -20));
    }

    private IEnumerator Moving(PositionYChanger parent, float byY)
    {
        parent.SetTargetFromCurrent(byY);
        yield return new WaitUntil(parent.IsFinished);
        parent.SetCurrent(10);
        StartCoroutine(Moving(parent, -20));
    }
}