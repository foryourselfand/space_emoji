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

    private List<IExecutable>[] _executableStarsArray;

    private void Awake()
    {
        _executableOnce = Helper.GetExecutablesFilledInList(executingOnce);
        _executableAllTime = Helper.GetExecutablesFilledInList(executingAllTime);

        _executableStarsArray = Helper.GetExecutablesFilledInArray(executingStars, 2);
    }

    public void OnStartRefresh()
    {
        ExecuteAll(_executableOnce);
    }

    public void EnvironmentRefresh()
    {
        ExecuteAll(_executableAllTime);
    }

    private static void ExecuteAll(List<IExecutable> executables)
    {
        foreach (var executable in executables)
            executable.Execute();
    }

    public void AllStarsRefresh()
    {
        for (var i = 0; i < _executableStarsArray.Length; i++)
            ConcreteStarsRefresh(i);
    }

    public void ConcreteStarsRefresh(int index)
    {
        foreach (var executableSmall in _executableStarsArray[index])
            executableSmall.Execute();
    }

//    private static void ExecuteAll(List<IExecutable>[] executables)
//    {
//        foreach (var executableBig in executables)
//        {
//            foreach (var executableSmall in executableBig)
//                executableSmall.Execute();
//        }
//    }
}