using System;
using UnityEngine;

public class FadersManager : MonoBehaviour
{
    public OpacityChanger sky;

    public void SkyOpacityAction()
    {
        sky.SetTarget(0);
    }
}