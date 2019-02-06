using System.Collections;
using UnityEngine;

public class GameCycle : MonoBehaviour
{
    public static bool CanClick;

    public WaiterGroup MenuButtons;

    public OpacityChanger Sky;

    public PositionChanger SpaceParent;
    public PositionChanger GroundParent;

    private void Start()
    {
        CanClick = false;
        ShowMenuButtons();
    }

    public void ShowMenuButtons()
    {
        StartCoroutine(TriggerMenuButtons());
    }

    public void OffGround()
    {
        Sky.SetCurrentAndTarget(1, 0);
        SpaceParent.SetTarget(new Vector2(0, -10));
        GroundParent.SetTarget(new Vector2(0, -10));
    }

    private IEnumerator TriggerMenuButtons()
    {
        yield return MenuButtons.Trigger();
        CanClick = !CanClick;
    }
}