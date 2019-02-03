using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesHolder : MonoBehaviour
{
    [SerializeField] protected List<Sprite> Sprites;

    public Sprite GetRandomSprite()
    {
        return Sprites[GetRandomIndex(Sprites)];
    }

    protected int GetRandomIndex(List<Sprite> sprites)
    {
        return Random.Range(0, sprites.Count);
    }
}