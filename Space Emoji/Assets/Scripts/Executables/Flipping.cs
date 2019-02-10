using UnityEngine;
using Random = UnityEngine.Random;

public class Flipping : IExecutableSimple
{
    public float startScale;

    protected override void ConcreteChildExecute(GameObject child)
    {
        var temp = new Vector2(startScale, startScale);
        temp.x *= Random.Range(0, 2) == 0 ? 1 : -1;
        child.transform.localScale = temp;
    }
}