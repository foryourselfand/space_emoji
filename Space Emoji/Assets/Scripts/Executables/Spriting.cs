using System.Collections.Generic;
using UnityEngine;

public class Spriting : IExecutable
{
    private SpritesHolder[] _holders;

    private void Awake()
    {
        _holders = GetComponents<SpritesHolder>();
    }

    public override void Execute()
    {
        var index = Random.Range(0, _holders.Length);
        var chosenHolder = _holders[index];

        foreach (var tempSprite in Family.Children)
            tempSprite.GetComponent<SpriteRenderer>().sprite = chosenHolder.GetRandomSprite();

        chosenHolder.ResetToDefault();
    }
}