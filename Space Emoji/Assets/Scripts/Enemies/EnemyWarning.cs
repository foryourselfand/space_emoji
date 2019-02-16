using System.Collections;
using UnityEngine;

public class EnemyWarning : MonoBehaviour
{
    public Vector2 offSet;

    public GameObject enemyMover;

    private void Start()
    {
        var tempPosition = transform.localPosition;
        tempPosition.x += offSet.x;
        tempPosition.y += offSet.y;
        transform.localPosition = tempPosition;
    }

    public IEnumerator Blick(Vector3 randomPosition, GameObject parentRotation)
    {
        yield return new WaitForSeconds(1);
        Instantiate(enemyMover, randomPosition, Quaternion.identity, parentRotation.transform);
        Destroy(gameObject);
    }
}