using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    public WaiterGroup menuButtons;
    public GameObject instructionsParent;

    private List<WaiterGroup> _instructions;

    private void Awake()
    {
        _instructions = Helper.GetChildrenFromParent<WaiterGroup>(instructionsParent);
    }

    private void Start()
    {
        instructionsParent.gameObject.SetActive(false);
    }

    public IEnumerator MenuButtonsAction()
    {
        yield return menuButtons.Trigger();
    }

    public IEnumerator InstructionsAction()
    {
        instructionsParent.gameObject.SetActive(true);
        StartCoroutine(ConcreteInstructionAction(_instructions[0]));
        StartCoroutine(ConcreteInstructionAction(_instructions[1]));
        yield break;
    }

    public IEnumerator ConcreteInstructionAction(WaiterGroup instruction)
    {
        yield return instruction.Trigger();
    }

    public IEnumerable MenuDone()
    {
        yield return menuButtons.IsDone();
    }
}