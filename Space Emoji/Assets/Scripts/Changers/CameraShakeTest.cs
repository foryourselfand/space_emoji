using System.Collections;
using UnityEngine;

public class CameraShakeTest : MonoBehaviour
{
    public FloatPrefab shakeBound;

    private Transform _cameraTransform;
    private Vector3 _cameraStartPosition;

    private void Awake()
    {
        _cameraTransform = GetComponent<Transform>();
    }

    public void ShakeLittle(DirectionType selfDirection)
    {
        StartCoroutine(Shaking(selfDirection, 4, shakeBound));
    }

    public IEnumerator Shaking(DirectionType selfDirection, int count, FloatPrefab bound)
    {
        var startPosition = _cameraTransform.localPosition;
        var randomCount = count + Random.Range(-1, 2);
        for (var i = 0; i < randomCount; i++)
        {
            var tempPosition = startPosition;

            tempPosition.y = Random.Range(-bound.value, bound.value);

            if (selfDirection == DirectionType.Left)
                tempPosition.x = Random.Range(-bound.value, 0);
            if (selfDirection == DirectionType.Right)
                tempPosition.x = Random.Range(0, bound.value);

            _cameraTransform.localPosition = tempPosition;
            yield return new WaitForSeconds(0.05F);
        }

        _cameraTransform.localPosition = startPosition;
    }
}