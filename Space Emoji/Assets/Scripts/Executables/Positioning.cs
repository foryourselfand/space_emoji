using System.Collections.Generic;
using UnityEngine;

public class Positioning : IExecutableSimple
{
    public Vector2 upLeft, downRight;

    protected override void ConcreteChildExecute(GameObject child)
    {
        child.transform.localPosition = new Vector2(
            Random.Range(upLeft.x, downRight.x),
            Random.Range(upLeft.y, downRight.y)
        );
    }
}