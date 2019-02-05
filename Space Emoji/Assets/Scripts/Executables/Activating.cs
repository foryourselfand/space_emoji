using System.Collections.Generic;
using UnityEngine;

public class Activating : IExecutable
{
    public int UpperRange;

    public override void Execute()
    {
        foreach (var children in Family.Children)
            children.SetActive(Random.Range(0, UpperRange) == 0);
    }
}