using System.Collections.Generic;
using UnityEngine;

public class Activating : IExecutable
{
    public int Probability;
    public int UpperBound;

    public override void Execute()
    {
        foreach (var children in Family.Children)
            children.SetActive(Random.Range(0, UpperBound) - Probability < 0);
    }
}