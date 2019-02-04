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
            var instance = Instantiate(Prefab, Family.Parent.transform);
            instance.transform.localPosition = new Vector2(Random.Range(-2.5F, 2.5F), Random.Range(-4.5F, -2F));
            instance.transform.parent = Family.Parent.transform;
        }

        SaveChilds();
    }
}