using System.Collections;
using UnityEngine;

public class EnemyWarning : ScaleChanger
{
    public Vector2 offSet;

    private void Start()
    {
        SetCurrent(0);

        var localPosition = transform.localPosition;
        localPosition = new Vector3(localPosition.x + offSet.x, localPosition.y + offSet.y);
        transform.localPosition = localPosition;

        StartCoroutine(Blick());
    }

    private IEnumerator Blick()
    {
        SetTarget(1);
        yield return new WaitUntil(IsFinished);

        yield return new WaitForSeconds(0.8F);

        SetTarget(0);
        yield return new WaitUntil(IsFinished);

        Destroy(gameObject);
    }
}