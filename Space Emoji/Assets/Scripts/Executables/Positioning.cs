using System.Collections.Generic;
using UnityEngine;

public class Positioning : IExecutable
{
    public Vector2 UpLeft, DownRight;

    public override void Execute()
    {
        foreach (var children in Family.Children)
            children.transform.localPosition = new Vector2(
                Random.Range(UpLeft.x, DownRight.x),
                Random.Range(UpLeft.y, DownRight.y)
            );
    }
}