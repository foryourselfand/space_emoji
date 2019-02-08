using System.Collections;
using UnityEngine;

public class GameCycle : MonoBehaviour
{
    public static bool CanClick;

    public EnvironmentManager EnvironmentManager;
    public MoversManager MoversManager;
    public ButtonsManager ButtonsManager;
    public FadersManager FadersManager;

    private void Start()
    {
        CanClick = false;
        EnvironmentManager.RefreshOnStart();
        StartCoroutine(GroundUp());
    }

    public void HideMenuButtons()
    {
        CanClick = false;
        EnvironmentManager.RefreshStars();
        StartCoroutine(MenuButtonsAction());
    }

    public void OffGround()
    {
        StartCoroutine(RocketOnPlace());
        MoversManager.OffGround();
        FadersManager.SkyOpacityAction();
    }

    private IEnumerator GroundUp()
    {
        EnvironmentManager.RefreshEnvironment();
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