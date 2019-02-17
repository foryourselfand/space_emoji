public class CameraSizeDependent : ClickDependent
{
    public CameraChanger cameraSize;

    public override void DependentAction(DirectionType directionType, float dependentValue)
    {
        cameraSize.SetTargetFromStart(dependentValue / step.value);
    }
}