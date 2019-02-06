using UnityEngine;

public class Scaling : IExecutable
{
    public float StartScale;
    public float OffSet;

    public override void Execute()
    {
        foreach (var child in Family.Children)
        {
            child.transform.localScale = new Vector2(
                StartScale + Random.Range(-OffSet, OffSet),
                StartScale + Random.Range(-OffSet, OffSet)
            );
        }
    }
}