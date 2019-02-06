using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public GameObject ExecutingOnce;
    public GameObject ExecutingAllTime;

    private List<IExecutable> _executableOnce;
    private List<IExecutable> _executableAllTime;

    private void Awake()
    {
        _executableOnce = Helper.GetFilled(ExecutingOnce);
        _executableAllTime = Helper.GetFilled(ExecutingAllTime);
    }

    private void Start()
    {
        ExecuteAll(_executableOnce);
        ExecuteAll(_executableAllTime);
    }

    public void RefreshAction()
    {
        ExecuteAll(_executableAllTime);
    }

    private static void ExecuteAll(List<IExecutable> executables)
    {
        foreach (var executable in executables)
            executable.Execute();
    }
}