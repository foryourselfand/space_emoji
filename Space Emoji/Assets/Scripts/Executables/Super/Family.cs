using System.Collections.Generic;
using UnityEngine;

public class Family : MonoBehaviour
{
    [HideInInspector] public GameObject parent;
    [HideInInspector] public List<GameObject> children;

    public void DefineParent()
    {
        parent = gameObject;
    }
}