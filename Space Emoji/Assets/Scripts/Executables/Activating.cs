using System.Collections.Generic;
using UnityEngine;

public class Activating : IExecutableSimple
{
    public int probability;
    public int upperBound;

    protected override void ConcreteChildExecute(GameObject child)
    {
        child.SetActive(Random.Range(0, upperBound) - probability < 0);
    }
}