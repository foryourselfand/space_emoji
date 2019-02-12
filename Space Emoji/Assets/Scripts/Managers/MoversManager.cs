using System.Collections;
using UnityEngine;

public class MoversManager : MonoBehaviour
{
    public PositionYChanger rocket;
    public PositionYChanger groundParent;
    public SpaceManager spaceManager;

    public IEnumerator GroundUpping()
    {
        rocket.transform.parent = groundParent.transform;

        groundParent.SetCurrent(-4);
        groundParent.SetTargetFromCurrent(4);
        yield return new WaitUntil(groundParent.IsFinished);

        rocket.transform.parent = groundParent.transform.parent;
    }

    public void GroundOff()
    {
        spaceManager.StartMove();
        groundParent.SetTargetFromCurrent(-4);
    }

    public IEnumerator RocketFlying()
    {
        rocket.SetTargetFromCurrent(1.66F);
        yield return new WaitUntil(rocket.IsFinished);

        rocket.SetTargetFromCurrent(-2.32F);
        yield return new WaitUntil(rocket.IsFinished);
    }
}