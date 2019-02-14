using System.Collections;
using UnityEngine;

public class GameCycle : MonoBehaviour
{
    public static bool CanClick;

    public EnvironmentManager environmentManager;
    public MoversManager moversManager;
    public ButtonsManager buttonsManager;
    public FadersManager fadersManager;
    public CameraManager cameraManager;
    public EnemyManager enemyManager;

    private void Start()
    {
        CanClick = false;
        environmentManager.OnStartRefresh();
        StartCoroutine(GroundUpping());
    }

    private IEnumerator GroundUpping()
    {
        environmentManager.EnvironmentRefresh();
        yield return moversManager.GroundUpping();
        yield return MenuButtonsShowing();
    }

    private IEnumerator MenuButtonsShowing()
    {
        yield return buttonsManager.MenuButtonsTriggering();
        yield return buttonsManager.MenuFinished();
        CanClick = true;
    }

    public void GroundOff()
    {
        StartCoroutine(RocketFlyingUp());
        fadersManager.SkyOut();
        StartCoroutine(MenuButtonsHiding());
    }

    private IEnumerator MenuButtonsHiding()
    {
        CanClick = false;
        environmentManager.StarsRefresh();
        yield return buttonsManager.MenuButtonsTriggering();
    }

    private IEnumerator RocketFlyingUp()
    {
        cameraManager.MoveIn();
        moversManager.RocketUp();
        yield return moversManager.GroundDowning();

        StartCoroutine(RocketFlyingDown());
    }

    private IEnumerator RocketFlyingDown()
    {
        cameraManager.MoveOut();
        yield return moversManager.RocketDown();

        StartCoroutine(ShowingInstructionButtons());
    }

    private IEnumerator ShowingInstructionButtons()
    {
        yield return buttonsManager.InstructionsTriggering();
        yield return buttonsManager.InstructionsFinished();
        buttonsManager.ActiveInputs();
        CanClick = true;
        StartCoroutine(enemyManager.Swapwning());
    }
}