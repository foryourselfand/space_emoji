using UnityEngine;

public class RefreshClicker : Clicker
{
    public EnvironmentManager environmentManager;

    protected override void Click()
    {
        environmentManager.EnvironmentRefresh();
    }
}