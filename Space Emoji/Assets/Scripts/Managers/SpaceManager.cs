using System.Collections;
using UnityEngine;

public class SpaceManager : MonoBehaviour
{
    public PositionYChanger rotationParent;
    public PositionYChanger firstParent, secondParent;

    private PositionYChanger _currentSky;

    public void StartMove()
    {
        _currentSky = firstParent;
        StartCoroutine(Move());

//        StartCoroutine(Moving(firstParent, -15));
//        StartCoroutine(Moving(secondParent, -30));
    }

    private IEnumerator Move()
    {
        rotationParent.SetTargetFromCurrent(-15);
        yield return new WaitUntil(rotationParent.IsFinished);
        if (_currentSky == firstParent)
        {
            _currentSky = secondParent;

            var tempPosition = firstParent.transform.localPosition;
            tempPosition.y += 30;
            firstParent.transform.localPosition = tempPosition;
        }
        else if (_currentSky == secondParent)
        {
            _currentSky = firstParent;

            var tempPosition = secondParent.transform.localPosition;
            tempPosition.y += 30;
            secondParent.transform.localPosition = tempPosition;
        }

        StartCoroutine(Move());
    }

    private IEnumerator Moving(PositionYChanger parent, float byY)
    {
        parent.SetTargetFromCurrent(byY);
        yield return new WaitUntil(parent.IsFinished);
        parent.SetCurrent(15);
        StartCoroutine(Moving(parent, -30));
    }
}