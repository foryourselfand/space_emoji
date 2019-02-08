using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class EnvironmentManager : MonoBehaviour
{
    public GameObject ExecutingOnce;
    public GameObject ExecutingAllTime;
    public GameObject ExecutingStars;

    private List<IExecutable> _executableOnce;
    private List<IExecutable> _executableAllTime;
    private List<IExecutable> _executableStars;

    private void Awake()
    {
        _executableOnce = Helper.GetFilled(ExecutingOnce);
        _executableAllTime = Helper.GetFilled(ExecutingAllTime);
        _executableStars = Helper.GetFilled(ExecutingStars);
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