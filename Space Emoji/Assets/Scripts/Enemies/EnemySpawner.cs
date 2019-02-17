using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public EnemyWarning enemyWarning;
    public GameObject enemyMover;

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

    public void SpawnWarning(GameObject parentUI, GameObject parentRotation)
    {
        var randomBoundIndex = Random.Range(0, _boundsRect.Count);
        var randomBound = _boundsRect[randomBoundIndex];
        var randomPosition = GetRandomPosition(randomBound);

        Instantiate(enemyWarning, randomPosition, Quaternion.identity, parentUI.transform);
        StartCoroutine(SpawnMover(randomPosition, parentRotation));
    }

    private IEnumerator SpawnMover(Vector3 randomPosition, GameObject parentRotation)
    {
        yield return new WaitForSeconds(1);
        Instantiate(enemyMover, randomPosition, Quaternion.identity, parentRotation.transform);
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