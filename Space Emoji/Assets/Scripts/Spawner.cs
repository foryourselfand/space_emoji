using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject Parent;
    public int SpawnCount;

    private List<GameObject> _instances;

    public List<GameObject> Instances
    {
        get { return _instances; }
    }

    private void Awake()
    {
        _instances = new List<GameObject>();
    }

    public void Spawn()
    {
        for (var i = 0; i < SpawnCount; i++)
        {
            var instance = Instantiate(Prefab, Parent.transform);
            instance.transform.localPosition = new Vector2(Random.Range(-2.5F, 2.5F), Random.Range(-4.5F, -2F));
            instance.transform.parent = Parent.transform;
            _instances.Add(instance);
        }
    }
}