using System;
using UnityEngine;

public class FadersManager : MonoBehaviour
{
    public CanvasOpacityChanger sky;

    public CanvasOpacityChanger canvasOpacityChanger;

    private void Start()
    {
        canvasOpacityChanger.SetCurrent(0);
    }

    public void ShowUI()
    {
        canvasOpacityChanger.SetTarget(1);
    }

    public void SkyOut()
    {
        sky.SetTarget(0);
    }
}