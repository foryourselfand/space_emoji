using System.Collections.Generic;
using UnityEngine;

public class Helper
{
    public static List<T> GetChildsFromParent<T>(GameObject parent)
    {
        var childList = new List<T>();
        var parentTransform = parent.transform;
        for (var i = 0; i < parentTransform.childCount; i++)
            childList.Add(parentTransform.GetChild(i).GetComponent<T>());

        return childList;
    }

    public static List<GameObject> GetChildsFromParent(GameObject parent)
    {
        var childList = new List<GameObject>();
        var parentTransform = parent.transform;
        for (var i = 0; i < parentTransform.childCount; i++)
            childList.Add(parentTransform.GetChild(i).gameObject);

        return childList;
    }
}