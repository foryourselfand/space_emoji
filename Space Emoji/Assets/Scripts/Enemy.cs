using UnityEngine;

public class Enemy : MonoBehaviour
{
    private FloatChanger _changer;

    public float target;

    private void Start()
    {
        _changer = GetComponent<FloatChanger>();
        _changer.DefineChangingValue();
        _changer.SetTargetFromCurrent(target);
        Invoke("DestroyAfter", 10);
    }

    private void DestroyAfter()
    {
        Destroy(gameObject);
    }
}