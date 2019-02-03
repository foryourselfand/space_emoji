using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonRepeatingSpritesHolder : SpritesHolder
{
    private List<Sprite> _nonRepeatingSprites;

    private void Start()
    {
        ResetToDefault();
    }

    public Sprite GetNonRepeatingSprite()
    {
        var indexToRemove = GetRandomIndex(_nonRepeatingSprites);
        var spriteToReturn = _nonRepeatingSprites[indexToRemove];
        _nonRepeatingSprites.RemoveAt(indexToRemove);
        return spriteToReturn;
    }

    public void ResetToDefault()
    {
        _nonRepeatingSprites = new List<Sprite>(Sprites);
    }
}