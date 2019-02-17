public class RotationDependent : ClickDependent
{
    public RotationChanger rotationChanger;

    public override void DependentAction(DirectionType directionType, float dependentValue)
    {
        var direction = 0;
        if (directionType == DirectionType.Left)
            direction = 1;
        else if (directionType == DirectionType.Right)
            direction = -1;
        rotationChanger.SetTargetFromStart(dependentValue * step.value * direction);
    }
}