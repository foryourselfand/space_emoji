using System.Collections.Generic;
using UnityEngine;

public class Spawning : IExecutable
{
    public GameObject prefab;
    public int spawnCount;

    public override void Execute()
    {
        for (var i = 0; i < spawnCount; i++)
        {
            var instance = Instantiate(prefab, family.parent.transform);
            instance.transform.parent = family.parent.transform;
        }

        SaveChildren();
    }
}