using System.Collections;
using UnityEngine;

public class SpaceManager : MonoBehaviour
{
    public PositionChanger parentFirst, parentSecond;

    public void StartMove()
    {
        StartCoroutine(Move(parentFirst, -10));
        StartCoroutine(Move(parentSecond, -20));
    }

    private IEnumerator Move(PositionChanger parent, float byY)
    {
        parent.SetTarget(new Vector2(0, byY));
        yield return new WaitUntil(parent.IsDone);
        parent.transform.localPosition += new Vector3(0, 20);
        StartCoroutine(Move(parent, -20));
    }
}