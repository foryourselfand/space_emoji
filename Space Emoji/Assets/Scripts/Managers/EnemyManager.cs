using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject parentUI;
    public GameObject parentRotation;

    public EnemySpawner enemySpawner;

    public IEnumerator Swapwning()
    {
        while (true)
        {
            enemySpawner.Spawn(parentUI, parentRotation);

            yield return new WaitForSeconds(2);
        }
    }
}