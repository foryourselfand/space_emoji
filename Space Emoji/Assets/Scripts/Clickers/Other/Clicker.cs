using UnityEngine;

public abstract class Clicker : MonoBehaviour
{
    public void ClickIfCan()
    {
        if (GameCycle.CanClick)
            Click();
    }

    protected abstract void Click();
}