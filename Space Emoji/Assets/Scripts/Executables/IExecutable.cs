using UnityEngine;

public abstract class IExecutable : MonoBehaviour
{
    public Family Family;

    public abstract void Execute();

    private void Awake()
    {
        Family.DefineParent();
        SaveChilds();
    }

    protected void SaveChilds()
    {
        Family.Children = Helper.GetChildrenFromParent(Family.Parent);
    }
}