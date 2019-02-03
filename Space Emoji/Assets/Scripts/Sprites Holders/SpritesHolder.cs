using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesHolder : MonoBehaviour
{
    [SerializeField] protected List<Sprite> Sprites;

    public virtual Sprite GetRandomSprite()
    {
        return Sprites[GetRandomIndex(Sprites)];
    }

    public virtual void ResetToDefault()
    {
    }

    protected int GetRandomIndex(List<Sprite> sprites)
    {
        return Random.Range(0, sprites.Count);
    }
}