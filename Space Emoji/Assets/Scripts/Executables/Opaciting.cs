using UnityEngine;

public class Opaciting : IExecutableOffSet
{
    protected override void ConcreteChildExecute(GameObject child)
    {
        var spriteRenderer = child.GetComponent<SpriteRenderer>();
        var temp = spriteRenderer.color;
        temp.a = Random.Range(offSet.value.x - offSet.value.y, offSet.value.x + offSet.value.y);
        spriteRenderer.color = temp;
    }
}