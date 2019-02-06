using UnityEngine;

public abstract class Clickable : MonoBehaviour
{
    private void OnMouseDown()
    {
        ActionOnClick();
    }

    public abstract void ActionOnClick();
}