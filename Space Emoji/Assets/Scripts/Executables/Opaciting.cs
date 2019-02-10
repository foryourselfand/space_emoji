using UnityEngine;

public class Opaciting : IExecutableOffSet
{
    protected override void ConcreteChildExecute(GameObject child)
    {
        var spriteRenderer = child.GetComponent<SpriteRenderer>();
        var temp = spriteRenderer.color;
        temp.a = Random.Range(startValue - offSet, startValue + offSet);
        spriteRenderer.color = temp;
    }
}