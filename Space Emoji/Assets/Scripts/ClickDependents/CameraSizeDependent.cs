public class CameraSizeDependent : ClickDependent
{
    public CameraChanger cameraSize;

    public override void DependentAction(DirectionType selfDirection, float rocketSpeed)
    {
        cameraSize.SetTargetFromStart(rocketSpeed / step.value);
    }
}