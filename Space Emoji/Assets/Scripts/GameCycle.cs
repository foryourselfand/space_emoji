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

    private bool _isFirstCLickOnInstructions;

    private void Start()
    {
        CanClick = false;
        _isFirstCLickOnInstructions = true;
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
        buttonsManager.InstructionsTrigger();
        yield return buttonsManager.InstructionsFinished();
        buttonsManager.ActiveInputs();
        CanClick = true;
    }

    public void FirstClickOnInstructions()
    {
        if (!_isFirstCLickOnInstructions) return;
        _isFirstCLickOnInstructions = false;
        buttonsManager.InstructionsTrigger();
        StartCoroutine(enemyManager.Swapwning());
    }
}