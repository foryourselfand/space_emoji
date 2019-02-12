using UnityEngine;

public abstract class ChangerBehavior : MonoBehaviour
{
    public abstract float Change(float current, float target, float speed);
}