using UnityEngine;

public class Rotating : IExecutable
{
    public override void Execute()
    {
        foreach (var child in Family.Children){
            child.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 361));}
    }
}