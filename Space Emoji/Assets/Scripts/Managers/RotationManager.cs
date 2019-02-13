using UnityEngine;

public class RotationManager : MonoBehaviour
{
    public RotationChanger rotationChanger;

    public float offSet;

    [HideInInspector] public int direction;


    public void Action(float angle)
    {
        Debug.Log(direction.ToString());
        rotationChanger.SetTargetFromStart(angle * offSet * direction);
    }
}