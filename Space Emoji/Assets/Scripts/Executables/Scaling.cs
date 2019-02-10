using UnityEngine;

public class Scaling : IExecutableOffSet
{
    protected override void ConcreteChildExecute(GameObject child)
    {
        child.transform.localScale = new Vector2(
            startValue + Random.Range(-offSet, offSet),
            startValue + Random.Range(-offSet, offSet)
        );
    }
}