using UnityEngine;

public class RefreshClicker : Clicker
{
    public EnvironmentManager EnvironmentManager;

    protected override void Click()
    {
        EnvironmentManager.RefreshAction();
    }
}