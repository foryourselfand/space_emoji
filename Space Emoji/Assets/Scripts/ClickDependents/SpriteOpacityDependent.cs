public class SpriteOpacityDependent : ClickDependent
{
    public SpriteOpacityChanger spriteOpacityChanger;

    public override void DependentAction(DirectionType directionType, float dependentValue)
    {
        spriteOpacityChanger.SetTargetFromStart(dependentValue * step.value);
    }
}