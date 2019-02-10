using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    public WaiterGroup menuButtons;

    public GameObject instructionButtonsParent;

    public GameObject inputParent;

    private List<WaiterGroup> _instructionButtons;

    private void Awake()
    {
        _instructionButtons = Helper.GetChildrenFromParent<WaiterGroup>(instructionButtonsParent);
    }

    private void Start()
    {
        instructionButtonsParent.SetActive(true);
    }

    public IEnumerator MenuButtonsTriggering()
    {
        yield return WaiterTriggering(menuButtons);
    }

    public IEnumerator InstructionsShowing()
    {
        StartCoroutine(WaiterTriggering(_instructionButtons[0]));
        StartCoroutine(WaiterTriggering(_instructionButtons[1]));
        yield break;
    }

    public IEnumerator MenuFinished()
    {
        yield return menuButtons.IsAllFinished();
    }

    private static IEnumerator WaiterTriggering(WaiterGroup waiter)
    {
        yield return waiter.Triggering();
    }
}