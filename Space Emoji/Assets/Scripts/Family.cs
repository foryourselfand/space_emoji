using System.Collections.Generic;
using UnityEngine;

public class Family : MonoBehaviour
{
    [HideInInspector] public GameObject Parent;
    [HideInInspector] public List<GameObject> Childs;

    public void DefineParent()
    {
        Parent = gameObject;
    }
}