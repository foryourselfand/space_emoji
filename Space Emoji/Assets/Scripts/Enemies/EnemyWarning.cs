using System.Collections;
using UnityEngine;

public class EnemyWarning : MonoBehaviour
{
    public Vector2 offSet;

    private void Start()
    {
        var localPosition = transform.localPosition;

        StartCoroutine(Blick());
        localPosition = new Vector3(localPosition.x + offSet.x, localPosition.y + offSet.y);

        transform.localPosition = localPosition;
    }

    private IEnumerator Blick()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}