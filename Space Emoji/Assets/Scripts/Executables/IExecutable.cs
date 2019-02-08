using UnityEngine;

public abstract class IExecutable : MonoBehaviour
{
    public Family Family;

    public abstract void Execute();

    private void Awake()
    {
        Family.DefineParent();
        SaveChildren();
    }

    protected void SaveChildren()
    {
        Family.Children = Helper.GetChildrenFromParent(Family.Parent);
    }
}