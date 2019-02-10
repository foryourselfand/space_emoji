using System.Collections;
using UnityEngine;

public class MoversManager : MonoBehaviour
{
    public Rocket rocket;
    public PositionChanger groundParent;
    public SpaceManager spaceManager;

    public IEnumerator GroundUpping()
    {
        rocket.transform.parent = groundParent.transform;

        groundParent.transform.localPosition = new Vector2(0, -4);
        groundParent.SetTargetFromCurrent(new Vector2(0, 4));
        yield return new WaitUntil(groundParent.IsFinished);

        rocket.transform.parent = groundParent.transform.parent;
    }

    public void GroundOff()
    {
        spaceManager.StartMove();
        groundParent.SetTargetFromCurrent(new Vector2(0, -4));
    }

    public IEnumerator RocketFlying()
    {
        yield return rocket.Fly();
    }
}