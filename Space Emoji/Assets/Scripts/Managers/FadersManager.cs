using System;
using UnityEngine;

public class FadersManager : MonoBehaviour
{
    public SpriteOpacityChanger sky;

    public void SkyOut()
    {
        sky.SetTarget(0);
    }
}