using System;
using UnityEngine;

public class FadersManager : MonoBehaviour
{
    public FloatOpacityChanger sky;

    public void SkyOut()
    {
        sky.SetTarget(0);
    }
}