using UnityEngine;

public abstract class IExecutableSimple : IExecutable
{
    public override void Execute()
    {
        foreach (var child in family.children)
        {
            ConcreteChildExecute(child);
        }
    }

    protected abstract void ConcreteChildExecute(GameObject child);
}