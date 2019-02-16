using System.Collections;
using UnityEngine;

public class WarningSymbol : MonoBehaviour
{
    public GameObject enemyMover;

    public IEnumerator Blick(Vector3 randomPosition, GameObject parentRotation)
    {
        yield return new WaitForSeconds(2);
        Instantiate(enemyMover, randomPosition, Quaternion.identity, parentRotation.transform);
    }
}