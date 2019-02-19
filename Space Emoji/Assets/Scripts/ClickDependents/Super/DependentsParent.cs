using System.Collections.Generic;
using UnityEngine;

public class DependentsParent : MonoBehaviour
{
    private List<ClickDependent> _clickDependents;

    private void Awake()
    {
        _clickDependents = Helper.GetChildrenFromParent<ClickDependent>(gameObject);
    }

    public void AllDependentsAction(DirectionType selfDirection, float rocketSpeed)
    {
        foreach (var depended in _clickDependents)
            depended.DependentAction(selfDirection, rocketSpeed);
    }
}