using System.Collections;
using UnityEngine;

public class GameCycle : MonoBehaviour
{
    public static bool CanClick;

    public WaiterGroup MenuButtons;

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
        // 
    }


    private IEnumerator TriggerMenuButtons()
    {
        yield return MenuButtons.Trigger();
        CanClick = !CanClick;
    }
}