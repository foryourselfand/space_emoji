using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CameraChanger cameraChanger;

    public FloatPrefab step;

    public void MoveByStep(float flyValue)
    {
        cameraChanger.SetTargetFromStart(flyValue / step.value);
    }

    public void MoveIn()
    {
        cameraChanger.SetTarget(3.5F);
    }

    public void MoveOut()
    {
        cameraChanger.SetTargetToStart();
    }
}