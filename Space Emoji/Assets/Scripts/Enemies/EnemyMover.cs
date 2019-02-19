using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public GameObject face;
    public float angle;
    public FloatPrefab speed;

    public Vector2Prefab offSetScale;
    public Vector2Prefab offSetRotation;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();

        var randomRotation = Random.Range(offSetRotation.value.x - offSetRotation.value.y,
            offSetRotation.value.x + offSetRotation.value.y);

        var instance = Instantiate(face, _transform.position, Quaternion.Euler(0, 0, randomRotation), _transform);

        var randomScale = Random.Range(offSetScale.value.x - offSetScale.value.y,
            offSetScale.value.x + offSetScale.value.y);
        instance.transform.localScale = new Vector3(randomScale, randomScale);

        _transform.localRotation = Quaternion.Euler(0, 0, angle);

        Invoke("DestroyAfter", 5);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed.value);
    }

    private void DestroyAfter()
    {
        Destroy(gameObject);
    }
}