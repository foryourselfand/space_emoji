using UnityEngine;

public class LerpAngle : ChangerBehavior
{
    public override float Change(float current, float target, float speed)
    {
        return Mathf.LerpAngle(current, target, speed * Time.deltaTime);
    }
}