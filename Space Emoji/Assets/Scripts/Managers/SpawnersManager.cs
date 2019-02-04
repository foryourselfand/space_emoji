using System.Collections.Generic;
using UnityEngine;

public class SpawnersManager : MonoBehaviour
{
    public List<Spawner> Spawners;

    public void SpawnAll()
    {
        foreach (var tempSpawner in Spawners)
            tempSpawner.Spawn();
    }
}