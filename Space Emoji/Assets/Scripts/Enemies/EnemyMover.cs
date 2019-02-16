using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public GameObject face;
    public float angle;
    public FloatPrefab speed;
    public FloatPrefab rocketY;

    private Transform _transform;

    private bool _isScoreAdded;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _isScoreAdded = false;

        Instantiate(face, _transform.position, Quaternion.Euler(0, 0, angle), _transform);
        _transform.localRotation = Quaternion.Euler(0, 0, angle);

        Invoke("DestroyAfter", 10);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed.value);
//        if (_isScoreAdded == false && transform.position.y <= rocketY.value)
//        {
//            _isScoreAdded = true;
//            Debug.Log("Score + 1");
//        }
    }

    private void DestroyAfter()
    {
        Destroy(gameObject);
    }
}