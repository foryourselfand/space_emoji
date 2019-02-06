using System.Collections;
using UnityEngine;

public class GameCycle : MonoBehaviour
{
    public static bool CanClick;

    public WaiterGroup WaiterGroup;

    private void Start()
    {
        CanClick = false;
        StartCoroutine(TriggerButtons());
    }

    private IEnumerator TriggerButtons()
    {
        yield return WaiterGroup.Trigger();
        CanClick = true;
    }
}