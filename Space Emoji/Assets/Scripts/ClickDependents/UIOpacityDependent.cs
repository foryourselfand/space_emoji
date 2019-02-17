using UnityEngine;

public class UIOpacityDependent : ClickDependent
{
    public CanvasOpacityChanger canvasChanger;

    public override void DependentAction(DirectionType directionType, float dependentValue)
    {
        canvasChanger.SetTargetFromStart(-1 * dependentValue * step.value);
    }
}