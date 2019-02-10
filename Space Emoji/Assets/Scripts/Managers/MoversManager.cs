using System.Collections;
using UnityEngine;

public class MoversManager : MonoBehaviour
{
    public PositionChanger rocket;
    public PositionChanger groundParent;
    public SpaceManager spaceManager;

    public IEnumerator GroundUpping()
    {
        groundParent.transform.localPosition = new Vector2(0, -4);
        groundParent.SetTarget(new Vector2(0, 4));
        yield return new WaitUntil(groundParent.IsFinished);
        rocket.transform.parent = groundParent.transform.parent;
    }

    public void GroundOff()
    {
        spaceManager.StartMove();
        groundParent.SetTarget(new Vector2(0, -4));
    }

    public IEnumerator RocketFlying()
    {
        rocket.SetTarget(new Vector2(0, 1.66F));
        yield return new WaitUntil(rocket.IsFinished);
        rocket.SetTarget(new Vector2(0, -2.32F));
        yield return new WaitUntil(rocket.IsFinished);
    }
}