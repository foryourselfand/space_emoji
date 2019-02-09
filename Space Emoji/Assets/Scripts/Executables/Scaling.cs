using UnityEngine;

public class Scaling : IExecutable
{
    public float startScale;
    public float offSet;

    public override void Execute()
    {
        foreach (var child in family.children)
        {
            child.transform.localScale = new Vector2(
                startScale + Random.Range(-offSet, offSet),
                startScale + Random.Range(-offSet, offSet)
            );
        }
    }
}