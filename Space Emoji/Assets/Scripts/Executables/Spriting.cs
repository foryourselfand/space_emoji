using System.Collections.Generic;
using UnityEngine;

public class Spriting : IExecutable
{
    public GameObject Holder;

    public override void Execute()
    {
        var holders = Holder.GetComponents<SpritesHolder>();
        var index = Random.Range(0, holders.Length);
        var chosenHolder = holders[index];

        foreach (var tempSprite in Family.Children)
            tempSprite.GetComponent<SpriteRenderer>().sprite = chosenHolder.GetRandomSprite();

        chosenHolder.ResetToDefault();
    }
}