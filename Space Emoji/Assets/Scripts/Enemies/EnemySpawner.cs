using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject movingEnemy;
    public List<Image> boundsImage;
    public Image prefabSymbol;

    private List<RectTransform> _boundsRect;
    private Vector3[] _vector;

    private Vector3 _randomPosition;
    private Image _instansedSymbol;

    private void Awake()
    {
        _boundsRect = new List<RectTransform>();
        foreach (var temp in boundsImage)
            _boundsRect.Add(temp.GetComponent<RectTransform>());
        _vector = new Vector3[4];
    }

    public void Spawn(GameObject parentRotation, GameObject parentUI)
    {
        var randomBoundIndex = Random.Range(0, _boundsRect.Count);
        var randomBound = _boundsRect[randomBoundIndex];
        _randomPosition = GetRandomPosition(randomBound);

        _instansedSymbol = Instantiate(prefabSymbol, parentUI.transform);

        var tempUIPosition = _instansedSymbol.transform.position;
        tempUIPosition.x = _randomPosition.x;
        _instansedSymbol.transform.position = tempUIPosition;

        Instantiate(movingEnemy, _randomPosition, Quaternion.identity, parentRotation.transform);
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