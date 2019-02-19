public class RotationDependent : ClickDependent
{
    public RotationChanger rotationChanger;

    public override void DependentAction(DirectionType selfDirection, float rocketSpeed)
    {
        var direction = 0;
        if (selfDirection == DirectionType.Left)
            direction = 1;
        else if (selfDirection == DirectionType.Right)
            direction = -1;
        rotationChanger.SetTargetFromStart(rocketSpeed * step.value * direction);
    }
}