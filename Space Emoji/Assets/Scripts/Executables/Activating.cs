using System.Collections.Generic;
using UnityEngine;

public class Activating : IExecutable
{
    public int probability;
    public int upperBound;

    public override void Execute()
    {
        foreach (var children in family.children)
            children.SetActive(Random.Range(0, upperBound) - probability < 0);
    }
}