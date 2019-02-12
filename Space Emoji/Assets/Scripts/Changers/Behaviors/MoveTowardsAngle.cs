using UnityEngine;

public class MoveTowardsAngle : ChangerBehavior
{
    public override float Change(float current, float target, float speed)
    {
        return Mathf.MoveTowardsAngle(current, target, speed * Time.deltaTime);
    }
}