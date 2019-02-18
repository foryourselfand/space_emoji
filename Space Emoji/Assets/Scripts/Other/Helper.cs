using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public static List<T> GetChildrenFromParent<T>(GameObject parent)
    {
        var childList = new List<T>();
        var parentTransform = parent.transform;
        for (var i = 0; i < parentTransform.childCount; i++)
            childList.Add(parentTransform.GetChild(i).GetComponent<T>());

        return childList;
    }

    public static List<GameObject> GetChildrenFromParent(GameObject parent)
    {
        var childList = new List<GameObject>();
        var parentTransform = parent.transform;
        for (var i = 0; i < parentTransform.childCount; i++)
            childList.Add(parentTransform.GetChild(i).gameObject);

        return childList;
    }

    public static List<IExecutable> GetExecutablesFilledInList(GameObject commonParent)
    {
        var executables = new List<IExecutable>();

        foreach (var concreteExecutableParent in GetChildrenFromParent(commonParent))
            executables.AddRange(GetChildrenFromParent<IExecutable>(concreteExecutableParent));

        return executables;
    }

    public static List<IExecutable>[] GetExecutablesFilledInArray(GameObject commonParent, int size)
    {
        var executables = new List<IExecutable>[size];

        var tempParent = GetChildrenFromParent(commonParent);
        for (var i = 0; i < tempParent.Count; i++)
        {
            executables[i] = new List<IExecutable>();
            executables[i].AddRange(GetChildrenFromParent<IExecutable>(tempParent[i]));
        }

        return executables;
    }
}