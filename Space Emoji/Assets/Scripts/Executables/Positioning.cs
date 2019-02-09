using System.Collections.Generic;
using UnityEngine;

public class Positioning : IExecutable
{
    public Vector2 upLeft, downRight;

    public override void Execute()
    {
        foreach (var children in family.children)
            children.transform.localPosition = new Vector2(
                Random.Range(upLeft.x, downRight.x),
                Random.Range(upLeft.y, downRight.y)
            );
    }
}