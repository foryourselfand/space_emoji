using UnityEngine;

public abstract class IExecutable : MonoBehaviour
{
    public Family family;

    public abstract void Execute();

    private void Awake()
    {
        family.DefineParent();
        SaveChildren();
    }

    protected void SaveChildren()
    {
        family.children = Helper.GetChildrenFromParent(family.parent);
    }
}