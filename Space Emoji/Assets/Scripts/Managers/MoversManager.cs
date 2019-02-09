using System.Collections;
using UnityEngine;

public class MoversManager : MonoBehaviour
{
    public PositionChanger rocket;
    public PositionChanger groundParent;
    public SpaceManager spaceManager;

    public IEnumerator GroundUp()
    {
        groundParent.transform.localPosition = new Vector2(0, -4);
        groundParent.SetTarget(new Vector2(0, 4));
        yield return new WaitUntil(groundParent.IsDone);
        rocket.transform.parent = groundParent.transform.parent;
    }

    public void OffGround()
    {
        spaceManager.StartMove();
        groundParent.SetTarget(new Vector2(0, -4));
    }

    public IEnumerator MoveRocket()
    {
        rocket.SetTarget(new Vector2(0, 1.66F));
        yield return new WaitUntil(rocket.IsDone);
        rocket.SetTarget(new Vector2(0, -2.32F));
        yield return new WaitUntil(rocket.IsDone);
    }
}