using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject SpawningParent;
    public GameObject PositioningParent;
    public GameObject SpritingParent;
    public GameObject ActivatingParent;

    private List<IExecutable> _spawnings;
    private List<IExecutable> _positionings;
    private List<IExecutable> _spritings;
    private List<IExecutable> _activating;

    private void Awake()
    {
        _spawnings = Helper.GetChildsFromParent<IExecutable>(SpawningParent);
        _positionings = Helper.GetChildsFromParent<IExecutable>(PositioningParent);
        _spritings = Helper.GetChildsFromParent<IExecutable>(SpritingParent);
        _activating = Helper.GetChildsFromParent<IExecutable>(ActivatingParent);
    }

    private void Start()
    {
        ExecuteAll(_spawnings);
        ExecuteAll(_positionings);
        ExecuteAll(_spritings);
        ExecuteAll(_activating);
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        ExecuteAll(_spritings);
        ExecuteAll(_positionings);
        ExecuteAll(_activating);
    }

    private static void ExecuteAll(List<IExecutable> executables)
    {
        foreach (var executable in executables)
            executable.Execute();
    }
}