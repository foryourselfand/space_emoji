using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _parent;
    [SerializeField] private int _spawnCount;

    public List<GameObject> Instances { private set; get; }

    private void Awake()
    {
        Instances = new List<GameObject>();
    }

    public void Spawn()
    {
        for (var i = 0; i < _spawnCount; i++)
        {
            var instance = Instantiate(_prefab, _parent.transform);
            instance.transform.localPosition = new Vector2(Random.Range(-2.5F, 2.5F), Random.Range(-4.5F, -2F)); 
            instance.transform.parent = _parent.transform;
            Instances.Add(instance);
        }
    }
}