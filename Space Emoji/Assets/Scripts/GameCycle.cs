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
        StartCoroutine(GroundUp());
    }

    public void HideMenuButtons()
    {
        StartCoroutine(MenuButtonsAction());
        CanClick = false;
    }

    public void OffGround()
    {
        StartCoroutine(RocketOnPlace());
        MoversManager.OffGround();
        FadersManager.SkyOpacityAction();
    }

    private IEnumerator GroundUp()
    {
        yield return MoversManager.GroundUp();
        yield return ShowMenuButtons();
    }

    private IEnumerator ShowMenuButtons()
    {
        yield return ButtonsManager.MenuButtonsAction();
        yield return ButtonsManager.MenuDone();
        CanClick = true;
    }

    private IEnumerator RocketOnPlace()
    {
        yield return MoversManager.MoveRocket();
        yield return ButtonsManager.InstructionsAction();
    }

    private IEnumerator MenuButtonsAction()
    {
        yield return ButtonsManager.MenuButtonsAction();
    }
}