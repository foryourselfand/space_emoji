using UnityEngine;

public class RefreshClicker : MonoBehaviour
{
    public Environment Environment;

    public void ActionOnClick()
    {
        Environment.RefreshAction();
    }
}