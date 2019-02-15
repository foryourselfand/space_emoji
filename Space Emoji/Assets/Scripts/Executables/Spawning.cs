using System.Collections.Generic;
using UnityEngine;

public class Spawning : IExecutable
{
    public GameObject prefab;
    public FloatPrefab spawnCount;

    public override void Execute()
    {
        for (var i = 0; i < spawnCount.value; i++)
        {
            var instance = Instantiate(prefab, family.parent.transform);
            instance.transform.parent = family.parent.transform;
        }

        SaveChildren();
    }
}