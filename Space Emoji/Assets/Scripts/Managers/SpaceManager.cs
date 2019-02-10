using System.Collections;
using UnityEngine;

public class SpaceManager : MonoBehaviour
{
    public PositionChanger parentFirst, parentSecond;

    public void StartMove()
    {
        StartCoroutine(Moving(parentFirst, -10));
        StartCoroutine(Moving(parentSecond, -20));
    }

    private IEnumerator Moving(PositionChanger parent, float byY)
    {
        parent.SetTarget(new Vector2(0, byY));
        yield return new WaitUntil(parent.IsFinished);
        parent.transform.localPosition += new Vector3(0, 20);
        StartCoroutine(Moving(parent, -20));
    }
}