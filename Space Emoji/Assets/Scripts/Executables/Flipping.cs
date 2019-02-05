using UnityEngine;

public class Flipping : IExecutable
{
    private Vector3 _startScale;

    private void Start()
    {
        _startScale = Family.Children[0].transform.localScale;
    }

    public override void Execute()
    {
        foreach (var child in Family.Children)
        {
            var temp = _startScale;
            temp.x = Random.Range(0, 2) == 0 ? _startScale.x : -_startScale.x;
            child.transform.localScale = temp;
        }
    }
}