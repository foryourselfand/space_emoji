using System.Collections.Generic;
using UnityEngine;

public class Activating : IExecutableSimple
{
    public Vector2Prefab probability;

    protected override void ConcreteChildExecute(GameObject child)
    {
        child.SetActive(Random.Range(0, probability.value.y) - probability.value.x < 0);
    }
}