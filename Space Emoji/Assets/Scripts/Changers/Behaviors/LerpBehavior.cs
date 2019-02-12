using UnityEngine;

public class LerpBehavior : ChangerBehavior
{
    public override float Change(float current, float target, float speed)
    {
        return Mathf.Lerp(current, target, speed * Time.deltaTime);
    }
}