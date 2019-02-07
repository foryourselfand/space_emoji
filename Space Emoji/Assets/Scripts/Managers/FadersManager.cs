using System;
using UnityEngine;

public class FadersManager : MonoBehaviour
{
    public OpacityChanger Sky;

    public void SkyOpacityAction()
    {
        Sky.SetTarget(0);
    }
}