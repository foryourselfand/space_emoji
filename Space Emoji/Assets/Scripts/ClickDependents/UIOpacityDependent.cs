using UnityEngine;

public class UIOpacityDependent : ClickDependent
{
    public CanvasOpacityChanger canvasChanger;

    public override void DependentAction(DirectionType selfDirection, float rocketSpeed)
    {
        canvasChanger.SetTargetFromStart(-1 * rocketSpeed * step.value);
    }
}