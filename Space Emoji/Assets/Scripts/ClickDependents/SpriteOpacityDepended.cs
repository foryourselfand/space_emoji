public class SpriteOpacityDepended : ClickDependent
{
    public OpacityChanger opacityChanger;

    public override void DependentAction(DirectionType directionType, float dependentValue)
    {
        opacityChanger.SetTargetFromStart(dependentValue * step.value);
    }
}