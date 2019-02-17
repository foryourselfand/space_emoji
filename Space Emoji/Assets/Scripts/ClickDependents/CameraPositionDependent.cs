public class CameraPositionDependent : ClickDependent
{
    public PositionYChanger cameraPosition;

    public override void DependentAction(DirectionType directionType, float dependentValue)
    {
        cameraPosition.SetTargetFromStart(dependentValue / step.value);
    }
}