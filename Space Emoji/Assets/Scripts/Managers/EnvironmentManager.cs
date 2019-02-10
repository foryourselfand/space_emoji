using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        _executableOnce = Helper.GetExecutablesFilled(executingOnce);
        _executableAllTime = Helper.GetExecutablesFilled(executingAllTime);
        _executableStars = Helper.GetExecutablesFilled(executingStars);
    }

    public void OnStartRefresh()
    {
        ExecuteAll(_executableOnce);
    }

    public void EnvironmentRefresh()
    {
        ExecuteAll(_executableAllTime);
    }

    public void StarsRefresh()
    {
        ExecuteAll(_executableStars);
    }

    private static void ExecuteAll(List<IExecutable> executables)
    {
        foreach (var executable in executables)
            executable.Execute();
    }
}