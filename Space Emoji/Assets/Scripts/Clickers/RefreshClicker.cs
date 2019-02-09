using UnityEngine;
using UnityEngine.Serialization;

public class RefreshClicker : Clicker
{
    public EnvironmentManager environmentManager;

    protected override void Click()
    {
        environmentManager.RefreshEnvironment();
    }
}