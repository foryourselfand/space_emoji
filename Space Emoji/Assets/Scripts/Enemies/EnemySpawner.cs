using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyBound bound;
    public GameObject enemyPrefab;

    public void Spawn(GameObject rotationParent)
    {
        Instantiate(enemyPrefab, bound.GetRandomPosition(), Quaternion.identity, rotationParent.transform);
    }
}