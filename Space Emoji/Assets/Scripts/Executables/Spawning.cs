using System.Collections.Generic;
using UnityEngine;

public class Spawning : IExecutable
{
    public GameObject Prefab;
    public int SpawnCount;

    public override void Execute()
    {
        for (var i = 0; i < SpawnCount; i++)
        {
            var instance = Instantiate(Prefab, family.parent.transform);
            instance.transform.parent = family.parent.transform;
        }

        SaveChildren();
    }
}