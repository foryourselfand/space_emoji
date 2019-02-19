using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject cameraGameObject;

    private CameraChanger _cameraChanger;
    private CameraShakeTest _cameraShake;

    private void Awake()
    {
        _cameraChanger = cameraGameObject.GetComponent<CameraChanger>();
        _cameraShake = cameraGameObject.GetComponent<CameraShakeTest>();
    }

    public void MoveIn()
    {
        _cameraChanger.SetTarget(3.5F);
    }

    public void MoveOut()
    {
        _cameraChanger.SetTargetToStart();
    }

    public void ShakeLittle(DirectionType selfDirection)
    {
        _cameraShake.ShakeLittle(selfDirection);
    }
}