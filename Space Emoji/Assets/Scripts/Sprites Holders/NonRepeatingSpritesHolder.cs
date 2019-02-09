using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonRepeatingSpritesHolder : SpritesHolder
{
    private List<Sprite> _nonRepeatingSprites;

    private void Awake()
    {
        ResetToDefault();
    }

    public override Sprite GetRandomSprite()
    {
        var indexToRemove = GetRandomIndex(_nonRepeatingSprites);
        var spriteToReturn = _nonRepeatingSprites[indexToRemove];
        _nonRepeatingSprites.RemoveAt(indexToRemove);
        return spriteToReturn;
    }

    public override void ResetToDefault()
    {
        _nonRepeatingSprites = new List<Sprite>(sprites);
    }
}