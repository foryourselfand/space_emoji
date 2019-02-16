using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public WarningSymbol warningSymbol;

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

    public void Spawn(GameObject parentUI, GameObject parentRotation)
    {
        var randomBoundIndex = Random.Range(0, _boundsRect.Count);
        var randomBound = _boundsRect[randomBoundIndex];
        var randomPosition = GetRandomPosition(randomBound);

        var warningInstance = Instantiate(warningSymbol, randomPosition, Quaternion.identity, parentUI.transform);

        warningInstance.StartCoroutine(warningInstance.Blick(randomPosition, parentRotation));
    }

    private Vector3 GetRandomPosition(RectTransform boundRect)
    {
        boundRect.GetWorldCorners(_vector);

        var tempX = Random.Range(_vector[0].x, _vector[2].x);
        var tempY = Random.Range(_vector[0].y, _vector[2].y);

//        Debug.Log(string.Format("{0} {1}", _vector[0].x.ToString(), _vector[2].x.ToString()));
//        Debug.Log(string.Format("{0} {1}", _vector[0].y.ToString(), _vector[2].y.ToString()));

        return new Vector3(tempX, tempY);
    }
}