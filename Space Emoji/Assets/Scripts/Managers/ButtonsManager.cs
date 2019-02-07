using System.Collections;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    public WaiterGroup MenuButtons;
    
    public IEnumerator MenuButtonsAction()
    {
        yield return MenuButtons.Trigger();
    }

    public IEnumerable MenuDone()
    {
        yield return MenuButtons.IsDone();
    }
}