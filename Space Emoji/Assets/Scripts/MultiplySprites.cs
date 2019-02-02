using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplySprites : MonoBehaviour
{
    public List<Sprite> Sprites;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetRandomSprite()
    {
        spriteRenderer.sprite = Sprites[Random.Range(0, Sprites.Count)];
    }
}