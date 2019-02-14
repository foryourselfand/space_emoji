using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CameraChanger cameraChanger;

    public float step;

    public void MoveByStep(float flyValue)
    {
        cameraChanger.SetTargetFromStart(flyValue / step);
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