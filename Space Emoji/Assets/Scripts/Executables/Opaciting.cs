using UnityEngine;

public class Opaciting : IExecutable
{
    public float StartOpacity;
    public float OffSet;
    
    public override void Execute()
    {
        foreach (var child in Family.Children)
        {
            var spriteRenderer = child.GetComponent<SpriteRenderer>();
            var temp = spriteRenderer.color;
            temp.a = Random.Range(StartOpacity - OffSet, StartOpacity + OffSet);
            spriteRenderer.color = temp;
        }
    }
}