using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SoundClicker : Clicker
{
    public Sprite onSprite;
    public Sprite offSprite;

    private Image _image;

    private string _soundState;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _soundState = PlayerPrefs.GetString("Sound", "On");
        ChangeSprite();
    }

    protected override void Click()
    {
        _soundState = _soundState.Equals("On") ? "Off" : "On";
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        _image.sprite = _soundState.Equals("On") ? offSprite : onSprite;
        PlayerPrefs.SetString("Sound", _soundState);
    }
}