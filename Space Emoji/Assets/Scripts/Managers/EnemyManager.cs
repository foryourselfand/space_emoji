using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject parentUI;
    public GameObject parentRotation;

    public List<EnemySpawner> enemySpawners;

    public IEnumerator Swapwning()
    {
        while (true)
        {
            var randomSpawnerIndex = Random.Range(0, enemySpawners.Count);
            var randomSpawner = enemySpawners[randomSpawnerIndex];

            randomSpawner.SpawnWarning(parentUI, parentRotation);

            yield return new WaitForSeconds(1.5F);
        }
    }
}