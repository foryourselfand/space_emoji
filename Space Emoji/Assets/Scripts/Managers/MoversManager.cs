using System.Collections;
using UnityEngine;

public class MoversManager : MonoBehaviour
{
    public PositionChanger Rocket;
    public PositionChanger GroundParent;
    public SpaceManager SpaceManager;

    public void OffGround()
    {
        SpaceManager.StartMove();
        GroundParent.SetTarget(new Vector2(0, -4));
    }

    public IEnumerator MoveRocket()
    {
        Rocket.SetTarget(new Vector2(0, 1.66F));
        yield return new WaitUntil(Rocket.IsDone);
        Rocket.SetTarget(new Vector2(0, -1.66F));
        yield return new WaitUntil(Rocket.IsDone);
    }
}