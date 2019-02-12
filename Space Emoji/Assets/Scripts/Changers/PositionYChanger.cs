public class PositionYChanger : PositionChanger
{
    protected override float GetCurrentRef()
    {
        return Transform.localPosition.y;
    }

    protected override void SetCurrentRef(float current)
    {
        var temp = Transform.localPosition;
        temp.y = current;
        Transform.localPosition = temp;
    }
}