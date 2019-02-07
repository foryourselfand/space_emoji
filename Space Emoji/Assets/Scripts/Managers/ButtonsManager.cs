using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    public WaiterGroup MenuButtons;
    public GameObject InstructionsParent;

    private List<WaiterGroup> _instructions;

    private void Awake()
    {
        _instructions = Helper.GetChildrenFromParent<WaiterGroup>(InstructionsParent);
    }

    private void Start()
    {
        InstructionsParent.gameObject.SetActive(false);
    }

    public IEnumerator MenuButtonsAction()
    {
        yield return MenuButtons.Trigger();
    }

    public IEnumerator InstructionsAction()
    {
        InstructionsParent.gameObject.SetActive(true);
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
        yield return MenuButtons.IsDone();
    }
}