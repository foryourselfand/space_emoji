using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class EnvironmentManager : MonoBehaviour
{
    public GameObject executingOnce;
    public GameObject executingAllTime;
    public GameObject executingStars;

    private List<IExecutable> _executableOnce;
    private List<IExecutable> _executableAllTime;
    private List<IExecutable> _executableStars;

    private void Awake()
    {
        _executableOnce = Helper.GetFilled(executingOnce);
        _executableAllTime = Helper.GetFilled(executingAllTime);
        _executableStars = Helper.GetFilled(executingStars);
    }

    public void RefreshOnStart()
    {
        ExecuteAll(_executableOnce);
    }

    public void RefreshEnvironment()
    {
        ExecuteAll(_executableAllTime);
    }

    public void RefreshStars()
    {
        ExecuteAll(_executableStars);
    }

    private static void ExecuteAll(List<IExecutable> executables)
    {
        foreach (var executable in executables)
            executable.Execute();
    }
}