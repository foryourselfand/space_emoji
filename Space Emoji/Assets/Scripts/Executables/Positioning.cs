using System.Collections.Generic;
using UnityEngine;

public class Positioning : IExecutableSimple
{
    public Vector2PairPrefab corners;

    protected override void ConcreteChildExecute(GameObject child)
    {
        child.transform.localPosition = new Vector2(
            Random.Range(corners.upLeft.x, corners.downRight.x),
            Random.Range(corners.upLeft.y, corners.downRight.y)
        );
    }
}