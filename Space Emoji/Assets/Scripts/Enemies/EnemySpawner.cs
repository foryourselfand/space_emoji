using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject movingEnemy;
    public List<Image> boundsImage;

    private List<RectTransform> _boundsRect;
    private Vector3[] _vector;

    private void Awake()
    {
        _boundsRect = new List<RectTransform>();
        foreach (var temp in boundsImage)
            _boundsRect.Add(temp.GetComponent<RectTransform>());
        _vector = new Vector3[4];
    }

    public void Spawn(GameObject rotationParent)
    {
        var randomBoundIndex = Random.Range(0, _boundsRect.Count);
        var randomBound = _boundsRect[randomBoundIndex];
        var randomPosition = GetRandomPosition(randomBound);

        Instantiate(movingEnemy, randomPosition, Quaternion.identity, rotationParent.transform);
    }

    private Vector3 GetRandomPosition(RectTransform boundRect)
    {
        boundRect.GetWorldCorners(_vector);

        var tempX = Random.Range(_vector[0].x, _vector[3].x);
        var tempY = Random.Range(_vector[0].y, _vector[3].y);

        return new Vector3(tempX, tempY);
    }
}