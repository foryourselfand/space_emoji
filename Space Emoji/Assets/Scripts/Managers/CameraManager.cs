using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CameraChanger cameraChanger;

    public void MoveIn()
    {
        cameraChanger.SetTarget(3.5F);
    }

    public void MoveOut()
    {
        cameraChanger.SetTargetToStart();
    }
}