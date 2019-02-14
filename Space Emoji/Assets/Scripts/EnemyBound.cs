using UnityEngine;
using UnityEngine.UI;

public class EnemyBound : MonoBehaviour
{
    public Image boundImage;

    private RectTransform _boundRect;
    private Vector3[] _vector;

    private void Awake()
    {
        
        _boundRect = boundImage.GetComponent<RectTransform>();
        _vector = new Vector3[4];
    }

    public Vector3 GetRandomPosition()
    {
        _boundRect.GetWorldCorners(_vector);

        var tempX = Random.Range(_vector[0].x, _vector[3].x);
        var tempY = Random.Range(_vector[0].y, _vector[3].y);

        return new Vector3(tempX, tempY);
    }
}