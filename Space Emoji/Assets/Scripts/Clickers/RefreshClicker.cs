using UnityEngine;

public class RefreshClicker : Clicker
{
    public Environment Environment;

    protected override void Click()
    {
        Environment.RefreshAction();
    }
}