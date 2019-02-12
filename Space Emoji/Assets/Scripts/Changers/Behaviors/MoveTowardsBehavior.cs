using UnityEngine;

public class MoveTowardsBehavior : ChangerBehavior
{
    public override float Change(float current, float target, float speed)
    {
        return Mathf.MoveTowards(current, target, speed * Time.deltaTime);
    }
}