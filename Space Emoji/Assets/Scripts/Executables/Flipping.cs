using UnityEngine;
using Random = UnityEngine.Random;

public class Flipping : IExecutable
{
    public float StartScale;

    public override void Execute()
    {
        foreach (var child in Family.Children)
        {
            var temp = new Vector2(StartScale, StartScale);
            temp.x *= Random.Range(0, 2) == 0 ? 1 : -1;
            child.transform.localScale = temp;
        }
    }
}