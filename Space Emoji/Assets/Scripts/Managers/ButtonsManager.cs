using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    public WaiterGroup menuButtons;

    public GameObject instructionButtonsParent;

    public GameObject inputButtonsParent;

    private List<WaiterGroup> _instructionButtons;


    private void Awake()
    {
        _instructionButtons = Helper.GetChildrenFromParent<WaiterGroup>(instructionButtonsParent);
    }

    private void Start()
    {
        instructionButtonsParent.SetActive(true);
        inputButtonsParent.SetActive(false);
    }

    public IEnumerator MenuButtonsTriggering()
    {
        yield return WaiterTriggering(menuButtons);
    }

    public IEnumerator MenuFinished()
    {
        yield return menuButtons.IsAllFinished();
    }

    public void InstructionsTrigger()
    {
        foreach (var instructionButton in _instructionButtons)
            StartCoroutine(WaiterTriggering(instructionButton));
    }

    public IEnumerator InstructionsFinished()
    {
        foreach (var instructionButton in _instructionButtons)
            yield return instructionButton.IsAllFinished();
    }

    public void ActiveInputs()
    {
        inputButtonsParent.SetActive(true);
    }

    private static IEnumerator WaiterTriggering(WaiterGroup waiter)
    {
        yield return waiter.Triggering();
    }
}