using UnityEngine;

public class Opaciting : IExecutable
{
    public float startOpacity;
    public float offSet;

    public override void Execute()
    {
        foreach (var child in family.children)
        {
            var spriteRenderer = child.GetComponent<SpriteRenderer>();
            var temp = spriteRenderer.color;
            temp.a = Random.Range(startOpacity - offSet, startOpacity + offSet);
            spriteRenderer.color = temp;
        }
    }
}