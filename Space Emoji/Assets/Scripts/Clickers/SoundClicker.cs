using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundClicker : MonoBehaviour
{
    public Sprite OnSprite;
    public Sprite OffSprite;

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

    public void ActionOnClick()
    {
        _soundState = _soundState.Equals("On") ? "Off" : "On";
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        _image.sprite = _soundState.Equals("On") ? OffSprite : OnSprite;
        PlayerPrefs.SetString("Sound", _soundState);
    }
}