using UnityEngine;

public class Scaling : IExecutableOffSet
{
    protected override void ConcreteChildExecute(GameObject child)
    {
        child.transform.localScale = new Vector2(
            offSet.value.x + Random.Range(-offSet.value.y, offSet.value.y),
            offSet.value.x + Random.Range(-offSet.value.y, offSet.value.y)
        );
    }
}