using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public GameObject parentRotation;
    public GameObject parentUI;

    public IEnumerator Swapwning()
    {
        while (true)
        {
            enemySpawner.Spawn(parentRotation, parentUI);

            yield return new WaitForSeconds(2);
        }
    }
}