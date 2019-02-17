public class CameraDependent : ClickDependent
{
    public CameraChanger cameraChanger;

    public override void DependentAction(DirectionType directionType, float dependentValue)
    {
        cameraChanger.SetTargetFromStart(dependentValue / step.value);
    }
}