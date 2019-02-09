using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpritesHolder : MonoBehaviour
{
   [SerializeField] protected List<Sprite> sprites;

    public virtual Sprite GetRandomSprite()
    {
        return sprites[GetRandomIndex(sprites)];
    }

    public virtual void ResetToDefault()
    {
    }

    protected int GetRandomIndex(List<Sprite> sprites)
    {
        return Random.Range(0, sprites.Count);
    }
}