using System;
using UnityEngine;

public class SoundClicker : Clickable
{
    public Sprite OnSprite;
    public Sprite OffSprite;

    private SpriteRenderer _spriteRenderer;

    private string _soundState;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _soundState = PlayerPrefs.GetString("Sound", "On");
        ChangeSprite();
    }

    public override void ActionOnClick()
    {
        _soundState = _soundState.Equals("On") ? "Off" : "On";
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        _spriteRenderer.sprite = _soundState.Equals("On") ? OffSprite : OnSprite;
        PlayerPrefs.SetString("Sound", _soundState);
    }
}