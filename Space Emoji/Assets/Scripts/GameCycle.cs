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
        moversManager.GroundOff();
        fadersManager.SkyOut();
        StartCoroutine(MenuButtonsHiding());
        StartCoroutine(RocketFlying());
    }


    private IEnumerator MenuButtonsHiding()
    {
        CanClick = false;
        environmentManager.StarsRefresh();
        yield return buttonsManager.MenuButtonsTriggering();
    }

    private IEnumerator RocketFlying()
    {
        cameraManager.Action(-1);
        yield return moversManager.RocketFlyUp();
        cameraManager.Action(0);
        yield return moversManager.RocketFlyDown();

        yield return buttonsManager.InstructionsTriggering();
        yield return buttonsManager.InstructionsFinished();
        buttonsManager.ActiveInputs();
        CanClick = true;
    }
}