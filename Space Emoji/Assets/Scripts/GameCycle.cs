using System.Collections;
using UnityEngine;

public class GameCycle : MonoBehaviour
{
    public static bool CanClick;

    public EnvironmentManager environmentManager;
    public MoversManager moversManager;
    public ButtonsManager buttonsManager;
    public FadersManager fadersManager;

    private void Start()
    {
        CanClick = false;
        environmentManager.RefreshOnStart();
        StartCoroutine(GroundUp());
    }

    public void HideMenuButtons()
    {
        CanClick = false;
        environmentManager.RefreshStars();
        StartCoroutine(MenuButtonsAction());
    }

    public void OffGround()
    {
        StartCoroutine(RocketOnPlace());
        moversManager.OffGround();
        fadersManager.SkyOpacityAction();
    }

    private IEnumerator GroundUp()
    {
        environmentManager.RefreshEnvironment();
        yield return moversManager.GroundUp();
        yield return ShowMenuButtons();
    }

    private IEnumerator ShowMenuButtons()
    {
        yield return buttonsManager.MenuButtonsAction();
        yield return buttonsManager.MenuDone();
        CanClick = true;
    }

    private IEnumerator RocketOnPlace()
    {
        yield return moversManager.MoveRocket();
        yield return buttonsManager.InstructionsAction();
    }

    private IEnumerator MenuButtonsAction()
    {
        yield return buttonsManager.MenuButtonsAction();
    }
}