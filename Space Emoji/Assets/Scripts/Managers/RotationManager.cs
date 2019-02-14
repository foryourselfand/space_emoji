using UnityEngine;

public class RotationManager : MonoBehaviour
{
    public RotationChanger rotationChanger;

    public float step;

    public void Action(DirectionType directionType, float angle)
    {
        var direction = 0;
        if (directionType == DirectionType.Left)
            direction = 1;
        else if (directionType == DirectionType.Right)
            direction = -1;
        rotationChanger.SetTargetFromStart(angle * step * direction);
    }
}