using System.Collections;
using UnityEngine;

public class GameCycle : MonoBehaviour
{
    public static bool CanClick;

    public ButtonsManager ButtonsManager;
    public MoversManager MoversManager;
    public FadersManager FadersManager;

    private void Start()
    {
        CanClick = false;
        StartCoroutine(StartButtons());
    }

    public void HideMenuButtons()
    {
        StartCoroutine(MenuButtonsTrigger());
        CanClick = false;
    }

    public void OffGround()
    {
        MoversManager.OffGround();
        FadersManager.SkyOpacityAction();
    }

    private IEnumerator MenuButtonsTrigger()
    {
        yield return ButtonsManager.MenuButtonsAction();
    }

    private IEnumerator StartButtons()
    {
        yield return ButtonsManager.MenuButtonsAction();
        yield return ButtonsManager.MenuDone();
        CanClick = true;
    }
}