using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject face;
    public float angle;
    public FloatPrefab speed;

    private Transform _transform;

    private void Start()
    {
        Debug.Log("Start in Enemy");
        _transform = GetComponent<Transform>();

        Instantiate(face, _transform.localPosition, Quaternion.Euler(0, 0, angle), _transform);
        _transform.localRotation = Quaternion.Euler(0, 0, angle);

        Invoke("DestroyAfter", 10);
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