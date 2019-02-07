using UnityEngine;

public class MoversManager : MonoBehaviour
{
    public PositionChanger SpaceParent;
    public PositionChanger GroundParent;

    public void OffGround()
    {
        SpaceParent.SetTarget(new Vector2(0, -10));
        GroundParent.SetTarget(new Vector2(0, -4));
    }
}