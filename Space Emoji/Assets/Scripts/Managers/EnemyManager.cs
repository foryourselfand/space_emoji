using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public GameObject rotationParent;

    public IEnumerator Swapwning()
    {
        while (true)
        {
            enemySpawner.Spawn(rotationParent);

            yield return new WaitForSeconds(2);
        }
    }
}