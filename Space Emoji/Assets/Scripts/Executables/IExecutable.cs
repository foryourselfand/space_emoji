using UnityEngine;

public abstract class IExecutable : MonoBehaviour
{
    public Family Family;

    public abstract void Execute();

    private void Awake()
    {
        SaveChilds();
    }

    protected void SaveChilds()
    {
        Family.Childs = Helper.GetChildsFromParent(Family.Parent);
    }
}