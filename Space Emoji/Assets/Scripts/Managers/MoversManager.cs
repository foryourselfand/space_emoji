using System.Collections;
using UnityEngine;

public class MoversManager : MonoBehaviour
{
    public PositionYChanger rocket;
    public PositionYChanger groundParent;
    public SpaceManager spaceManager;

    public IEnumerator GroundUpping()
    {
        groundParent.gameObject.SetActive(true);
        rocket.transform.parent = groundParent.transform;

        groundParent.SetCurrent(-4);
        groundParent.SetTargetFromCurrent(4);
        yield return new WaitUntil(groundParent.IsFinished);
    }

    public IEnumerator GroundDowning()
    {
        rocket.transform.parent = groundParent.transform.parent;
        
        spaceManager.StartMove();
        groundParent.SetTargetFromCurrent(-4);
        yield return new WaitUntil(groundParent.IsFinished);
        
        groundParent.gameObject.SetActive(false);
    }

    public void RocketUp()
    {
        rocket.SetTargetFromCurrent(10);
    }

    public IEnumerator RocketDown()
    {
        rocket.SetTarget(-2.32F);
        yield return new WaitUntil(rocket.IsFinished);
    }

    public IEnumerator RocketFlying()
    {
        rocket.SetTargetFromCurrent(1.66F);
        yield return new WaitUntil(rocket.IsFinished);
        rocket.SetTargetFromCurrent(-2.32F);
        yield return new WaitUntil(rocket.IsFinished);
    }
}