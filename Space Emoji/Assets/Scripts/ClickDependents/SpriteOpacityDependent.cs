public class SpriteOpacityDependent : ClickDependent
{
    public SpriteOpacityChanger spriteOpacityChanger;

    public override void DependentAction(DirectionType selfDirection, float rocketSpeed)
    {
        spriteOpacityChanger.SetTargetFromStart(rocketSpeed * step.value);
    }
}