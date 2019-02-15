using UnityEngine;

public class Rotating : IExecutableOffSet
{
    protected override void ConcreteChildExecute(GameObject child)
    {
        child.transform.eulerAngles =
            new Vector3(0, 0, Random.Range(
                offSet.value.x - offSet.value.y,
                offSet.value.x + offSet.value.y)
            );
    }
}