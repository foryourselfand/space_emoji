using System;
using UnityEngine;

public class FadersManager : MonoBehaviour
{
    public OpacityChanger sky;

    public void SkyOut()
    {
        sky.SetTarget(0);
    }
}