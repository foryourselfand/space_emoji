using System.Collections;
using UnityEngine;

public class SpaceManager : MonoBehaviour
{
    public PositionYChanger spaceParent;

    public PositionYChanger[] starsParents;
    private int _starsParentsIndex;

    public void ResetToStart()
    {
        spaceParent.SetCurrent(0);
        starsParents[0].SetCurrent(0);
        starsParents[1].SetCurrent(15);
    }

    public void StartMove()
    {
        _starsParentsIndex = 0;
        StartCoroutine(StarsMoving());
    }

    private IEnumerator StarsMoving()
    {
        spaceParent.SetTargetFromCurrent(-15);

        yield return new WaitUntil(spaceParent.IsFinished);

        starsParents[_starsParentsIndex].AddToCurrent(30);
        _starsParentsIndex = Mathf.Abs(1 - _starsParentsIndex);

        StartCoroutine(StarsMoving());
    }
}