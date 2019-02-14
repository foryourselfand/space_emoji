using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CameraChanger cameraChanger;

    public float step;

    public void Action(float flyValue)
    {
        cameraChanger.SetTargetFromStart(flyValue / step);
    }
}